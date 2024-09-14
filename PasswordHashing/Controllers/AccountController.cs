
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PasswordHashing.Models;
using PasswordHashing.ViewModels;
using PasswordHashing.Models;
using PasswordHashing.ViewModels;
using PasswordHashing.Data;

namespace PasswordHashing.Controllers
{

    public class AccountController : Controller
    {
        // Simulating a database for POC purposes
        private static List<User> users = new List<User>();

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Hash the password
                string hashedPassword = HashingService.HashPassword(model.Password);

                // Create a new User object
                User newUser = new User
                {
                    Username = model.Username,
                    PasswordHash = hashedPassword
                };
                

                // Simulate saving to the database
                users.Add(newUser);

                ViewBag.Message = "User registered successfully!";
                return View("Success"); // Redirect to success view or dashboard

                //using (var session = NHibernateHelper.CreateSession())
                //{
                //    using (var transaction = session.BeginTransaction())
                //    {

                //        session.Save(newUser);
                //        transaction.Commit();
                //        ViewBag.Message = "User registered successfully!";
                //        return View("Success");
                //    }
                //}
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Find the user by username (from the simulated database for this example)
                User user = users.FirstOrDefault(u => u.Username == model.Username);

                if (user != null)
                {
                    // Hash the entered password
                    string hashedPassword = HashingService.HashPassword(model.Password);

                    // Compare the hashed passwords
                    if (user.PasswordHash == hashedPassword)
                    {
                        ViewBag.Message = "Login successful!";
                        return View("Success"); // Redirect to success view or dashboard
                    }
                    else
                    {
                        // Add error message to the Password field in ModelState
                        ModelState.AddModelError("Password", "Incorrect password.");
                    }
                }
                else
                {
                    // Add error message for Username if not found
                    ModelState.AddModelError("Username", "Username not found.");
                }
            }

            return View(model);
        }

        //[HttpPost]
        //public ActionResult Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //using (var session = NHibernateHelper.CreateSession())
        //        //{
        //        //    var userLogin = session.Query<User>().SingleOrDefault(u => u.Username == model.Username);
        //        //    if (userLogin != null)
        //        //    {
        //        //        string hashedPassword = HashingService.HashPassword(model.Password);
        //        //        if (userLogin.PasswordHash == hashedPassword)
        //        //        {
        //        //            ViewBag.Message = "Login successful!";
        //        //            return View("Success"); // Redirect to success view or dashboard
        //        //        }
        //        //        else
        //        //        {
        //        //            ModelState.AddModelError("", "Invalid password.");
        //        //        }
        //        //    }
        //        //    else
        //        //    {
        //        //        ModelState.AddModelError("", "Username not found.");
        //        //    }
        //        //}




        //        // Find the user by username (from the simulated database for this example)
        //        User user = users.FirstOrDefault(u => u.Username == model.Username);

        //        if (user != null)
        //        {
        //            // Hash the entered password
        //            string hashedPassword = HashingService.HashPassword(model.Password);

        //            // Compare the hashed passwords
        //            if (user.PasswordHash == hashedPassword)
        //            {
        //                ViewBag.Message = "Login successful!";
        //                return View("Success"); // Redirect to success view or dashboard
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Invalid password.");
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Username not found.");
        //        }
        //    }

        //    return View(model);
        //}
    }

}