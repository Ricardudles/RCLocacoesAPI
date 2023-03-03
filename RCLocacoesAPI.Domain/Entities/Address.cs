using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Domain.Entities
{
    public class Address : BaseModel
    {

        public int Id { get; set; }
        public int ZipCode { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string AdditionalDetails { get; set; }
    }
}
