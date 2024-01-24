namespace Domain.Interfaces
{
    //Общий интерфейс всех сущностей, которые могут храниться в бд
    public interface IEntity
    {
        public Guid Id { get; }
    }
}
