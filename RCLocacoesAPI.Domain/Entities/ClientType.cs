using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Domain.Entities
{
    public class ClientType : BaseModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
