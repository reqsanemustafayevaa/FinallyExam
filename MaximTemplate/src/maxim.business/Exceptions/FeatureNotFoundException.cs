using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim.business.Exceptions
{
    public class FeatureNotFoundException:Exception
    {
        public string PropertyName { get; set; }
        public FeatureNotFoundException()
        {

        }
        public FeatureNotFoundException(string? message):base(message) 
        {

        }
        public FeatureNotFoundException(string propertyname,string? message):base(message)
        {
            PropertyName = propertyname;

        }
    }
}
