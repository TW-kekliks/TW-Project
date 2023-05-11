using eUseControl.BusinessLogic.DBModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eUseControl.Controllers
{
    public class AcceptRejectController : Controller
    {
        [HttpPost]
        public ActionResult Accept()
        {
            string Id = Request.Form["Id"];
            var ConvertID = Convert.ToInt32(Id);
            using (var db = new AppointmentContext())
            {
                var app = db.Users.Where(a => a.Id == ConvertID).FirstOrDefault();
                app.Status = Domain.Entities.Enums.ARole.ACCEPTED;
                db.SaveChanges();
            }
            return RedirectToAction("doctor", "User");
        }
        [HttpPost]
        public ActionResult Reject()
        {
            string Id = Request.Form["Id"];
            var ConvertID = Convert.ToInt32(Id);
            using (var db = new AppointmentContext())
            {
                var app = db.Users.Where(a => a.Id == ConvertID).FirstOrDefault();
                app.Status = Domain.Entities.Enums.ARole.REJECTED;
                db.SaveChanges();
            }
            return RedirectToAction("doctor", "User");
        }
        [HttpPost]
        public ActionResult AcceptComment()
        {
            string Id = Request.Form["Id"];
            var ConvertID = Convert.ToInt32(Id);
            using (var db = new CommentContext())
            {
                var app = db.Comment.Where(a => a.Id == ConvertID).FirstOrDefault();
                app.Status = Domain.Entities.Enums.ARole.ACCEPTED;
                db.SaveChanges();
            }
            return RedirectToAction("doctor", "User");
        }
        [HttpPost]
        public ActionResult RejectComment()
        {
            string Id = Request.Form["Id"];
            var ConvertID = Convert.ToInt32(Id);
            using (var db = new CommentContext())
            {
                var app = db.Comment.Where(a => a.Id == ConvertID).FirstOrDefault();
                app.Status = Domain.Entities.Enums.ARole.REJECTED;
                db.SaveChanges();
            }
            return RedirectToAction("doctor", "User");
        }
    }
}