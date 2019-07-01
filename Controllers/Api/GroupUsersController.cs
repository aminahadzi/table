using Coffee_Table.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Coffee_Table.Controllers.Api
{
    public class GroupUsersController : ApiController
    {
        public ApplicationDbContext _context;

        public GroupUsersController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("api/groupusers/{UserId}")]
        public IEnumerable<GroupUsers> GetGroupUsers(string UserId) {
           return _context.GroupUsers.Include(g=>g.group).Include(g => g.group.applicationUser).Where(g => g.applicationUserId.Equals(UserId)).ToList();
        }

        public IEnumerable<GroupUsers> GetGroupUsers() {
            return _context.GroupUsers.Include(g=>g.group).Include(g=>g.applicationUser).ToList();
        }
        
    }
}
