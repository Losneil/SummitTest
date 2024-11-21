using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class ServiceBase
    {
        private DataDict Dictionary { get; set; }

        public ServiceBase(DataDict dataDict) 
        {
            
        }

        public abstract ServiceState StartService();
    }
}
