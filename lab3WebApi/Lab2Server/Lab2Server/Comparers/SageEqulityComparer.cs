using Lab2Server.Entities;
using System.Collections.Generic;

namespace Lab2Server.Comparers
{
    public class KeyEqulityComparer : IEqualityComparer<KeyEntity>
    {
        public bool Equals(KeyEntity x, KeyEntity y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(KeyEntity obj)
        {
            return obj.Id;
        }
    }
}