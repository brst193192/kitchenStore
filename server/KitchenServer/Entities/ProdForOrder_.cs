using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Entities
{
    public class ProdForOrder_
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }

        //הכלות
        //[ForeignKey("ProductId")]
        public Product_ Product { get; set; } = new Product_();

        //[ForeignKey("OrderId")]
        public Order_ Order { get; set; } = new Order_();


    }
}
