using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Database.Models
{
    [Table("Order")]
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdateOn { get; set; }// ngày thanh toán

        [ForeignKey("CustomerId")]
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<Details> Details { get; set; } = new HashSet<Details>();
    }
}
