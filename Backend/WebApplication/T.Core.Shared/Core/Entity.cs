using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T.Core.Shared
{
    public abstract class Entity : Entity<int>, IEntity
    {
    }

    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
