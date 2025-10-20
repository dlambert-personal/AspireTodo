using AspireTodo.ApiService.Data;
using TodoStates.CrossCutting.CQRS;

namespace AspireTodo.ApiService.Todo.CreateToDo;

internal class CreateTodoCommandHandler(TodoContext context) : ICommandHandler<CreateTodoCommand, CreateTodoResponse>
{
    public async Task<CreateTodoResponse> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        //todo: implement mapster
        var todoitem = new TodoItem
        {
            Id = Guid.NewGuid(),
            CustomerCode = command.CustomerCode,
            CustomerName = command.CustomerName
        };

        context.TodoItems.Add(todoitem);
        await context.SaveChangesAsync(cancellationToken);

        return new CreateTodoResponse(todoitem.Id);
    }
}
