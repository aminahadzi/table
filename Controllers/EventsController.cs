using Coffee_Table.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coffee_Table.Controllers
{
    public class EventsController : Controller
    {
        public ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Events
        public ActionResult Index()
        {
            return View();
        }

        
    }
}