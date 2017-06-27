using System.Collections.Generic;

namespace MVCPL.Models.PaginationVM
{
    public class CommentPageVM
    {
        public IEnumerable<CommentVM> Comments { get; set; }
        public PageVM Page { get; set; }
    }
}