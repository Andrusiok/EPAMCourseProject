using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities
{
    public class ImageEntity:IBLLEntity, IEquatable<ImageEntity>
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Path { get; set; }

        public bool Equals(ImageEntity other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return (Id == other.Id && PostId == other.PostId && Path == other.Path);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() == typeof(ImageEntity)) return Equals((ImageEntity)obj);
            else return false;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
