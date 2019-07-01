using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Coffee_Table.Models
{
    public class Group
    {

       /* public Group(string groupAdminId)
        {
            applicationUserId = groupAdminId;
        }*/
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

        public ApplicationUser applicationUser { get; set; }
        [Required]
        public string applicationUserId { get; set; }
       }


}