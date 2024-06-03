using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookApp.Domain.model
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        public string AccountNumber { get; set; }
    }
}
