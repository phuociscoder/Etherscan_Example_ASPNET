using Etherscan.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etherscan.Repository
{
    public abstract class Repository 
    {
        public Repository(string connectionString){
            ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }
    }
}
