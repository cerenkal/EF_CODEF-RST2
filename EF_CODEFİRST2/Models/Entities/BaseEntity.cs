using EF_CODEFİRST2.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CODEFİRST2.Models.Entities
{
    abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime? CreateDate { get; set; } //oluşturma tarihi ? inin sebebi nullable olması yani boi geçilebilir
        public DateTime? ModifiedDate { get; set; } //Güncellme tarihi
        public DateTime? DeleteDate { get; set; } //silme tarihi
        public DateStatus Status { get; set; }

        public BaseEntity()
        {
            CreateDate = DateTime.Now;
            Status = DateStatus.Inserted;
        }
    }
}
