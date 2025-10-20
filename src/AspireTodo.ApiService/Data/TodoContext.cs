
namespace AspireTodo.ApiService.Data
{
    public class TodoContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<TodoItem> TodoItems { get; set; } = default!;

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "todo.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoItem>().HasData(
                new TodoItem
                {
                    Id = Guid.Parse("e455f48f-35d1-4fa4-aaf1-4f7fcf5da22a"),
                    CustomerCode = "CUST-001",
                    CustomerName = "John Doe"
                },
                new TodoItem
                {
                    Id = Guid.Parse("0c30022b-8617-47ec-8e2d-6f327f507084"),
                    CustomerCode = "CUST-002",
                    CustomerName = "Jane Smith"
                }
            );
        }
    }
}
