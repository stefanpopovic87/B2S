namespace B2S.Infrastructure.Dtos
{
    public class EntityDto<TKey>
    {
        public TKey Id { get; set; }
    }

    public class EntityDto : EntityDto<int>
    {
    }
}