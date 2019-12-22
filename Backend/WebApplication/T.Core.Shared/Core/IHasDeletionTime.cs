using System;

namespace T.Core.Shared
{
    interface IHasDeletionTime: ISoftDelete
    {
        DateTime? DeletionTime { get; set; }
    }
}
