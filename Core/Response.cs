using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Response
    {
        public DataDict? Dictionary { get; set; }
        public string? MessageError { get; set; }
        public ServiceState ServiceState { get; set; }
    }
}
