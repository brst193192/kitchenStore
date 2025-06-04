using DTO_Entity_Common.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Entities
{
    public class ProdForCart_
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public bool IsSelect { get; set; }

        //הכלות
        //[ForeignKey("ProductId")]
        public Product_ Product { get; set; } = new Product_();

        //[ForeignKey("UserId")]
        //public virtual User? User { get; set; }
    }
}
