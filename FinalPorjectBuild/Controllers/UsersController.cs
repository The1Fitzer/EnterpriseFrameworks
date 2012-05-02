using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FinalPorjectBuild.Models;

namespace FinalPorjectBuild.Controllers
{ 
    public class UsersController : Controller
    {
         //
        // GET: /Users/

        public ViewResult Index()
        {
            //return View(db.Users.ToList());
            return View();
        }

        //
        // GET: /Users/Details/5

        public ViewResult Details(int id)
        {
            return View();
        }

        //GET: Log On
        public ActionResult LogOn()
        {
            return View();
        }

        //POST: Log On
        [HttpPost]
        public ActionResult LogOn(UserLogin login)
        {
            if (ModelState.IsValid)
            {
                BusinessLogic.UserLogin _ul = new BusinessLogic.UserLogin
                {
                    Name = login.Name,
                    Password = login.Password,
                };

                _ul.LogIn();

                return RedirectToAction("Index", "Home");
            }
            return View(login);
        }

        //GET: Log Off
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Users/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Users/Create

        [HttpPost]
        public ActionResult Create(UserCreate users)
        {
            if (ModelState.IsValid)
            {
                BusinessLogic.User _u = new BusinessLogic.User
                {
                    Name = users.Name,
                    Role_id = users.Role_id,
                    Password = users.Password
                };

                _u.Save();
                return RedirectToAction("LogOn");  
            }

            return View(users);
        }

        
        //
        // GET: /Users/Edit/5
 
        public ActionResult Edit(string name)
        {
            return View();
        }

        //
        // POST: /Users/Edit/5

        [HttpPost]
        public ActionResult Edit(Edit up)
        {
            if (ModelState.IsValid)
            {
                BusinessLogic.UpdateUser _up = new BusinessLogic.UpdateUser
                {
                    Name = up.NewName,
                    Phone = up.Phone,
                    Old = up.OldName
                };

                _up.Update();
                return RedirectToAction("Index");
            }
            return View(up);
        }

        //
        // GET: /Users/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}