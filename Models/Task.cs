namespace Minimal_API.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }

        public Guid CategoryId { get; set; }

        public string Description { get; set; }

        public Priority TaskPriority { get; set; }

        public DateTime DateTimeCreated { get; set; }

        public virtual Category Category { get; set; }

    }
    
    public enum Priority
    {
        Low,
        Mid,
        High
    }
}
