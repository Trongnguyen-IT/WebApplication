using System;

namespace T.Core.Shared
{
    public interface IHasModificationTime
    {
        DateTime? LastModificationTime { get; set; }
    }
}
