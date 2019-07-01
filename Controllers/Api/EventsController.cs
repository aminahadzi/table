using Coffee_Table.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Coffee_Table.Controllers.Api
{
    public class EventsController : ApiController
    {


        public ApplicationDbContext _context;

        public EventsController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("api/events/getevents/{groupId}")]
        public IEnumerable<Event> GetEvents(int groupId)
        {
            return _context.Events.Where(e=>e.GroupId == groupId).ToList();
            }

        [HttpPost]
        public void SaveEvent(Event evnt) {
            //Debug.WriteLine("Usli smo u save events a id je " + evnt.Id + " a description je " + evnt.Description);
            var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            if (evnt.Id < 1)
            {
                evnt.UserId = user.Id;
                _context.Events.Add(evnt);
            }
            else {
                var eventFromDatabase = _context.Events.Where(e => e.Id == evnt.Id).SingleOrDefault();
                if (eventFromDatabase != null) {
                   
                    eventFromDatabase.Subject = evnt.Subject;
                    eventFromDatabase.Description = evnt.Description;
                    eventFromDatabase.Start = evnt.Start;
                    eventFromDatabase.End = evnt.End;
                    eventFromDatabase.isFullDay = evnt.isFullDay;
                    eventFromDatabase.ThemeColor = evnt.ThemeColor;
                }
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e) {
                Console.WriteLine(e);
            }
           
        }
        

        [HttpPost]
        [Route("api/events/DeleteEvent/{eventId}")]
        public void DeleteEvent(int eventId){
            var eventFromDatabase = _context.Events.Where(e => e.Id == eventId).SingleOrDefault();
            if (eventFromDatabase != null) {
                _context.Events.Remove(eventFromDatabase);
                _context.SaveChanges();
            }
        }
    }


}
