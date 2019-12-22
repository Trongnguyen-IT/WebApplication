using System;

namespace T.Core.Shared
{
    public class BaseEntity : Entity, IAudited, IPassivable, ISoftDelete
    {
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime CreationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }
    }
}
