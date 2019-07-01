using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coffee_Table.Models
{
    public class GroupUsers
    {
        
        [Required]
        public int id { get; set; }
        [Required]
        public string applicationUserId { get; set; }

        public ApplicationUser applicationUser { get; set; }

        [Required]
        public int groupId { get; set; }

        public Group group { get; set; }
    }
}