using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.DTO
{
    public class DALPost : IDALEntity
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Annotation { get; set; }
        public string Text { get; set; }
    }
}
