using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class DataService : ServiceBase
    {

        public DataService(DataDict dataDict):base(dataDict) 
        {
            
        }

        public override ServiceState StartService()
        {
            return Process();
        }

        protected abstract ServiceState Process();
    }
}
