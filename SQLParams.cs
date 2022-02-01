using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CityDetails.Models
{
    public class SQLParams
    {
       
            public string Key { get; set; }
            public dynamic Value { get; set; }
            public SqlDbType DataType { get; set; }
        
    }
}
