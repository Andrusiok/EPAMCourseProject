using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities
{
    public class CommentEntity:IBLLEntity, IEquatable<CommentEntity>
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Entity { get; set; }

        public bool Equals(CommentEntity other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return (Id == other.Id && PostId == other.PostId && UserId == other.UserId && Equals(Date, other.Date));
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() == typeof(CommentEntity)) return Equals((CommentEntity)obj);
            else return false;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
