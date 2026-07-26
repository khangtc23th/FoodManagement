using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? LoginName { get; set; }
        public string? PassWord { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
    }
}
