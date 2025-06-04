using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Entities
{
    public class Product_
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string ?Model { get; set; }
        public string Desc { get; set; } = "";
        public double Price { get; set; }
        public string Img { get; set; } = "";
        public int AmountInStock { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        //הכלות
        //[ForeignKey("CategoryId")]
        public Category_ Category { get; set; } = new Category_();
    }
}
