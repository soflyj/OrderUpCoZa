using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderUp.Domain.Entities
{
    public class ProductInventory
    {
        public int Id { get; set; }
        [Required]
        public string Key { get; set; }  // e.g., Size or Variant name
        public int Value { get; set; }   // e.g., Stock count
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
