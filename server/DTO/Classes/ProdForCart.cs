using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Entity_Common.Classes
{
    public class ProdForCart
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public bool IsSelect { get; set; }
        public Product? Product { get; set; } = new Product();

    }
}
