using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CODEFİRST2.Models.Entities
{
    class Product : BaseEntity
    {
        public string ProductName { get; set; }

        private decimal _unitPrice;
        public decimal UnitPrice { get => _unitPrice; set => _unitPrice = value<0 ? Math.Abs(value) : value; }
    }
}
