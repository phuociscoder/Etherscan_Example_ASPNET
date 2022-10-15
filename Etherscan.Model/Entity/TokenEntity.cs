using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etherscan.Model.Entity
{
    public class TokenEntity
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int Total_Supply { get; set; }
        public string Contract_Address { get; set; }
        public int Total_Holders { get; set; }
    }
}
