using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee_Table.ViewModels
{
    public class JoinViewModel
    {
        public string userId { get; set; }

        public int groupId { get; set; }

        public string password { get; set; }

        public string message { get; set; }
    }
}