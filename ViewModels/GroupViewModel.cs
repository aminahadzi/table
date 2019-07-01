using Coffee_Table.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee_Table.ViewModels
{
    public class GroupViewModel
    {
        public IEnumerable<GroupUsers> groupUsers { get; set; }

        public Group group { get; set; }

        public ApplicationUser currentUser { get; set; }
    }
}