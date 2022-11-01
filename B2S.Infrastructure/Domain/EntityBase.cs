namespace B2S.Infrastructure.Domain
{
    public abstract class EntityBase<TId>
    {
        public TId Id { get; set; }
    }

    public class EntityBase : EntityBase<int>
    {
    }

}
