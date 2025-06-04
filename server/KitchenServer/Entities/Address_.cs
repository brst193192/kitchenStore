using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REPOSITORY.Entities
{
    [ComplexType]
    public class Address_
    {
        public string City { get; set; } = "";
        public string Street { get; set; } = "";
        public int? BuildNumber { get; set; }
        public int HouseNumber { get; set; }
    }
}
