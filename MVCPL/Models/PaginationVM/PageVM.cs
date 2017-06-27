using System;

namespace MVCPL.Models.PaginationVM
{
    public class PageVM
    {
        public int Number { get; set; }
        public int Size { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / Size);
    }
}