using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CODEFİRST2.Models.Entities
{
    class Category:BaseEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
