namespace StudentGroupSystem.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public BaseEntity(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return $"ID: {Id}";
        }
    }
}
