using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maxim.core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CrteateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
