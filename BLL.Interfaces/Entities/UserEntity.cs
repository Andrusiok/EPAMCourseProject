using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces.Entities
{
    public class UserEntity:IBLLEntity, IEquatable<UserEntity>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public int RoleID { get; set; }

        public bool Equals(UserEntity other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return (Id == other.Id && Name == other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() == typeof(UserEntity)) return Equals((UserEntity)obj);
            else return false;
        }

        public override int GetHashCode() => base.GetHashCode();
    }
}
