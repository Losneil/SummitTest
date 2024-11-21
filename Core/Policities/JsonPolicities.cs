using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Core.Policities
{
    public class JsonPolicities : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            if (string.IsNullOrEmpty(name) || !char.IsUpper(name[0]))
                return name;

            return char.ToLower(name[0]) + name[1..];
        }
    }
}
