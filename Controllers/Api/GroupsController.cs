using Coffee_Table.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;



namespace Coffee_Table.Controllers.Api
{
    public class GroupsController : ApiController
    {
        public ApplicationDbContext _context;

        public GroupsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Group> GetGroups() {

            return _context.Groups.Include(g => g.applicationUser).ToList();
            }
    }
}
