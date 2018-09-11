using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Module1.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        [RegularExpression(@".+\@.+\..+", ErrorMessage = "Email Id format is invalid. Please provide a valid email")]
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
