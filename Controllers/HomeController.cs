using Coffee_Table.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Coffee_Table.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
                if (user.isGroupAdmin)
                {
                    int groupId = _context.Groups.Where(g => g.applicationUserId.Equals(user.Id)).Single().Id;
                    return RedirectToAction("Group", new RouteValueDictionary(
                    new { controller = "Groups", action = "Group", id = groupId }));
                }
                else {
                    return RedirectToAction("ListGroups", new RouteValueDictionary(
                    new { controller = "Groups", action = "ListGroups", userName = user.UserName }));
                }
            }
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
    }
}