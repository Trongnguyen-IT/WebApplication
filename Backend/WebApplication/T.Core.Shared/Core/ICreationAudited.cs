namespace T.Core.Shared
{
    public interface ICreationAudited: IHasCreationTime
    {
        long? CreatorUserId { get; set; }
    }
}
