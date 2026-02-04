using TodoStates.Shared.CQRS;

namespace AspireTodo.ApiService.Todo.CreateToDo;

public record CreateTodoRequest(string Subject, string Description, string CreatedBy);
public record CreateTodoResponse(Guid Id);
public record CreateTodoCommand(string Subject, string Description, string CreatedBy) : ICommand<CreateTodoResponse>;