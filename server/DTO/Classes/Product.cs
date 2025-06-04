using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Entity_Common.Classes
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string ?Model { get; set; }
        public string Desc { get; set; } = "";
        public double Price { get; set; }
        public string Img { get; set; } = "";
        public int AmountInStock { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; } = null;
    }
}
