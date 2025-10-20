using TodoStates.CrossCutting.CQRS;

namespace AspireTodo.ApiService.Todo.CreateToDo;

public record CreateTodoRequest(string CustomerCode, string CustomerName);
public record CreateTodoResponse(Guid Id);
public record CreateTodoCommand(string CustomerCode, string CustomerName) : ICommand<CreateTodoResponse>;
