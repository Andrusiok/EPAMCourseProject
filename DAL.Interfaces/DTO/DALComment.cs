using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DALComment:IDALEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Entity { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
