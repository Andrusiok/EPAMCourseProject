using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DALBlog : IDALEntity
    {
        public int Id { get; set; }

        public int UserID { get; set; }
    }
}
