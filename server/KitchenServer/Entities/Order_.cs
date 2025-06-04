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
    public class Order_
    {
        [Key]
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ReceiveDate { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public double Sum { get; set; }


        //הכלות 
        public List<ProdForOrder_> Products { get; set; } = new List<ProdForOrder_>();

    }
}
