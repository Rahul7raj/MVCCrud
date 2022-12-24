using MyThirdProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyThirdProject.Controllers
{
    public class StudentController : Controller
    {
        practicedbEntities1 dbobj = new practicedbEntities1(); //created database object
        // GET: Student
        public ActionResult CreateStudent()  //for display view
        {
            return View();
        }

        [HttpPost]
        public ActionResult StoreStudent(tbl_student Model) // for storing data into db
        {
            if (ModelState.IsValid)
            {
                tbl_student tobj = new tbl_student(); //table object
                tobj.FName = Model.FName;
                tobj.LName = Model.LName;
                tobj.Mobile_Number = Model.Mobile_Number;
                tobj.Email = Model.Email;
                tobj.About = Model.About;

                dbobj.tbl_student.Add(tobj);
                dbobj.SaveChanges();

                return RedirectToAction("ReadData");
            }
            return View("CreateStudent");
        }

        [HttpGet]
        public ActionResult ReadData() //displaying data
        {
            using(dbobj)
            {
                var data = dbobj.tbl_student.ToList();
                return View(data);
            }
        }
    }
}