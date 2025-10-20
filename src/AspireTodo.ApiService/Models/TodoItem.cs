namespace AspireTodo.ApiService.Models
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; }
        public string CustomerCode { get; set; } = default!;
        public string CustomerName { get; set; } = default!;
    }
}
