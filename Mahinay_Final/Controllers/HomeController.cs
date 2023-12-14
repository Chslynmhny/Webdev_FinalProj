using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mahinay_Final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AddUser()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult AddUserToDatabase(FormCollection fc)
        {
            String firstName = fc["firstname"];
            String lastName = fc["lastname"];
            String email = fc["email"];
            String diko = fc["password"];

            user use = new user();
            use.firstname = firstName;
            use.lastname = lastName;
            use.email = email;
            use.password = diko;
            use.roleID = 2;

            friendsEntities fe = new friendsEntities();
            fe.users.Add(use);
            fe.SaveChanges();

            //insert the code that will save these information to the DB

            return RedirectToAction("ShowUser");
        }

        public ActionResult ShowUser()
        {
            friendsEntities fe = new friendsEntities();
            var userList = (from a in fe.users
                            select a).ToList();

            ViewData["UserList"] = userList;
            return View();
        }

        [HttpPost]
        public ActionResult UserUpdate(int id)
        {
            int x = id;


            friendsEntities user = new friendsEntities();

            var User = (from a in user.users where a.userId == x select a).ToList();


            ViewData["User"] = User;

            return View();
            //  return RedirectToAction("UserUpdate");  // Redirect to the appropriate action or view
        }
        [HttpPost]
        public ActionResult Update(FormCollection up, int id)
        {
            friendsEntities rdbe = new friendsEntities();
            user u = (from a in rdbe.users
                      where a.userId == id
                      select a).FirstOrDefault();

            String new_first_name = up["new_firstname"];
            String new_last_name = up["new_lastname"];
            String new_email = up["new_email"];
            String new_password = up["new_password"];

            u.firstname = new_first_name;
            u.lastname = new_last_name;
            u.email = new_email;
            u.password = new_password;

            rdbe.SaveChanges();

            return RedirectToAction("ShowUser");
        }


        public ActionResult UserDelete(int id)
        {
            friendsEntities rdbe = new friendsEntities();
            user u = (from a in rdbe.users
                      where a.userId == id
                      select a).FirstOrDefault();
            rdbe.users.Remove(u);
            rdbe.SaveChanges();

            return RedirectToAction("ShowUser");
        }
    }
}