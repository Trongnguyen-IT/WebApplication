namespace T.Core.Shared
{
    interface IDeletionAudited: IHasDeletionTime
    {
        long? DeleterUserId { get; set; }
    }
}
