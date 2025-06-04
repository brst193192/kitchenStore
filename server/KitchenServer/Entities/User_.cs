using REPOSITORY.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Entities
{
    public class User_
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public DateTime Birthday { get; set; }

        //הכלות
        public Address_ Address { get; set; } = new Address_();
        //public List<ProdForCart_> Cart { get; set; } = new List<ProdForCart_>();
        //public List<Order_> Orders { get; set; } = new List<Order_>();
    }
}
