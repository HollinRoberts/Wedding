using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wedding.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;


namespace Wedding.Controllers
{
    public class LoginController : Controller
    {
        // GET: /Home/
        private WeddingContext _context;
 
        public LoginController(WeddingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {   
            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            List<Object> error = new List<object>();
            ViewBag.errors= error;
            return View("login");
        }
        [HttpPost]
        [Route("Submit")]
    
        public IActionResult Submit(regvalidate NewUser)
        {
            if (ModelState.IsValid)
            {   User User1 =_context.user.SingleOrDefault(user=>user.email==NewUser.Email);
                PasswordHasher<regvalidate> Hasher = new PasswordHasher<regvalidate>();
                NewUser.Password = Hasher.HashPassword(NewUser, NewUser.Password);
                if( User1==null){
                    User New= new User
                    {
                        first = NewUser.FirstName,
                        last = NewUser.LastName,
                        email = NewUser.Email,
                        password = NewUser.Password,
                    };
                    _context.Add(New);
                    _context.SaveChanges();
               
                User1 =_context.user.SingleOrDefault(user=>user.email==NewUser.Email);
                HttpContext.Session.SetInt32("userId", User1.userid);
                HttpContext.Session.SetString("name", User1.first);
                ViewBag.Name=User1.first;
                
                   return RedirectToAction("Main", "home");
                }else{
                    ModelState.AddModelError("RegisterFail", "User already exists.");
                    ViewBag.errors = ModelState.Values;
                    return View("login");
                    }
                }
            
            else
            {
                Console.WriteLine("in else");
             
                ViewBag.errors = ModelState.Values;
            
                Console.WriteLine(ViewBag.errors);
                return View("login");
            }
           
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login userLogin )
        {   
            if (ModelState.IsValid)
            {
             User User1 = _context.user.SingleOrDefault(user=>user.email==userLogin.Email);
                
                if(User1!=null){
                    var Hasher = new PasswordHasher<User>();
                    if(User1.email==userLogin.Email &&  (0 != Hasher.VerifyHashedPassword(User1, User1.password, userLogin.Password))){
                        HttpContext.Session.SetInt32("userId", User1.userid);
                        HttpContext.Session.SetString("name", User1.first);
                        ViewBag.Name=User1.first;
                        
                  
                        return RedirectToAction("Main","Home");
                     }else{
                        ModelState.AddModelError("LogFail", "Invalid Login");
                        ViewBag.errors = ModelState.Values;
                        Console.WriteLine(ViewBag.errors);
                         return View("login");
                     }
                }else{
                    ModelState.AddModelError("LogFail", "Invalid Login");
                    ViewBag.errors = ModelState.Values;
                    return View("login");
                }
            }
             else
            {
                Console.WriteLine("in else");
             
                ViewBag.errors = ModelState.Values;
            
                Console.WriteLine(ViewBag.errors);
                return View("login");
            }
        }
        [HttpPost]
        [Route("action")]
        public IActionResult update(int value)
        {   
           
        int? id = HttpContext.Session.GetInt32("userId");
        User Account = _context.user.Include(users=>users.wedding).SingleOrDefault(user=>user.userid==(int)id);

        // Activity action= new Activity
        //             {
        //                 userid = (int)id,
        //                 change = value,
                        
        //             };
        //             _context.Add(action);
        //             _context.SaveChanges();
        //        Account.ballance=Account.ballance+value;
        //        _context.SaveChanges();
        //         ViewBag.Name=Account.first;
        //         ViewBag.Ballance=Account.ballance;
        // ViewBag.Transactions=Account.activity;
                return View("account");
            
        }

    }
}
 