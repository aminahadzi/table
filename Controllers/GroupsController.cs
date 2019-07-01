using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Coffee_Table.ViewModels;
using Coffee_Table.Models;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Coffee_Table.Controllers
{
    public class GroupsController : Controller
    {
        private ApplicationDbContext _context;

        public GroupsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Groups
        public ActionResult Index()
        {
            return Content("Sad smo usli u nasu kreiranu grupu");
        }

        public ActionResult CreateGroup(string userName) {
            if (!(User.IsInRole("CanCreateGroup")))
                return RedirectToAction("Register","Account");

           
            GroupFormViewModel viewModel = new GroupFormViewModel
            {
                group = new Group(),
               sourcePage = "Create your own group",
               AdminId = _context.Users.SingleOrDefault(u=>u.UserName == userName).Id
            };

            return View("GroupForm",viewModel);
        }

        [Route("groups/listgroups/{userName}")]
        public ActionResult ListGroups(string userName) {

            ListGroupViewModel viewModel = new ListGroupViewModel {
                UserId = _context.Users.SingleOrDefault(u => u.UserName == userName).Id
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Group group) {
            if (!ModelState.IsValid)
            {
                var viewmodel = new GroupFormViewModel
                {
                    group = group,
                    sourcePage = "Create your own group",
                    AdminId = group.applicationUserId
                };
                return View("GroupForm", viewmodel);


            }
            else {

                _context.Groups.Add(group);
                _context.SaveChanges();

                var GroupUser = new GroupUsers() {
                    applicationUserId = group.applicationUserId,
                    groupId = group.Id
                };
                _context.GroupUsers.Add(GroupUser);
                _context.SaveChanges();


                return RedirectToAction("Group", new RouteValueDictionary(
     new { controller = "Groups", action = "Group", id = group.Id }));
            }
            
        }


        public ActionResult GroupInfo (int id){

            var viewmodel = new GroupViewModel
            {
                group = _context.Groups.Include(g=>g.applicationUser).SingleOrDefault(g=>g.Id == id),
                groupUsers = _context.GroupUsers.Where(g => g.groupId == id).Include(g=>g.applicationUser).ToList()
            };

            return View(viewmodel);

        }

        [Route("groups/join/{UserId}/{GroupId}/{Message?}")]
        public ActionResult Join (int GroupId, string UserId, string Message){

            var userJoined = _context.GroupUsers.Where(g => (g.groupId == GroupId && g.applicationUserId.Equals(UserId))).SingleOrDefault();
            if (userJoined != null) {
                return RedirectToAction("Group", new RouteValueDictionary(
   new { controller = "Groups", action = "Group", id = GroupId }));
            }

            JoinViewModel viewmodel = new JoinViewModel
            {
                groupId = GroupId,
                userId = UserId,
                message = Message
                
            };
            return View(viewmodel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PasswordCheck(JoinViewModel viewModel) {
            var test = _context.Groups.Where(g => (g.Password.Equals(viewModel.password) && g.Id == viewModel.groupId )).SingleOrDefault();
            if ( test == null)
            {
                return RedirectToAction("Join", "Groups", new { UserId = viewModel.userId, GroupId = viewModel.groupId, Message = "Incorrect Password! Please Try Again" });

            }
            else {
                GroupUsers groupUser = new GroupUsers
                {
                    applicationUserId = viewModel.userId,
                    groupId = viewModel.groupId
                };
                _context.GroupUsers.Add(groupUser);
                _context.SaveChanges();

                // return RedirectToAction("Group", "Groups", new { id = viewModel.groupId});
                return RedirectToAction("Group", new RouteValueDictionary(
    new { controller = "Groups", action = "Group", id = viewModel.groupId }));

            }


        }

        [Route("Groups/Group/{id}")]
        public ActionResult Group(int id)
        {

            var viewmodel = new GroupViewModel
            {
                group = _context.Groups.Include(g => g.applicationUser).SingleOrDefault(g => g.Id == id),
                groupUsers = _context.GroupUsers.Where(g => g.groupId == id).Include(g => g.applicationUser).ToList(),
                currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(System.Web.HttpContext.Current.User.Identity.GetUserId())
        };

            return View(viewmodel);

        }

        [Route("groups/mygroups/{userId}")]
        public ActionResult MyGroups(string userId) {
            ListGroupViewModel viewModel = new ListGroupViewModel
            {
                UserId = userId
            };
            return View(viewModel);
        }

    }
}