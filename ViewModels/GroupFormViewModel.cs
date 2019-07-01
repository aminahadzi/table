using Coffee_Table.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coffee_Table.ViewModels
{
    public class GroupFormViewModel
    {
        public Group group { get; set; }

        public string sourcePage { get; set; }

        public string AdminId { get; set; }

       
    }
}