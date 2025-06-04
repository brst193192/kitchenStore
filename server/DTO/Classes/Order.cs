using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Entity_Common.Classes
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ReceiveDate { get; set; }
        public int UserId { get; set; }
        public double Sum { get; set; }


        //הכלות
        public List<ProdForOrder>? Products { get; set; } = new List<ProdForOrder>();
        //public User? User { get; set; }

    }
}
