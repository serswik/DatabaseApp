using SQLite;

namespace DatabaseApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
