using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Coffee_Table.Models
{
    public class Event
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        public string Description { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Start { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? End { get; set; }

        public string  ThemeColor { get; set; }


        public bool isFullDay { get; set; }
        [Required]
        public int GroupId { get; set; }

        public Group Group { get; set; }

        [Required]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        
    }
}