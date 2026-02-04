using AspireTodo.ApiService.Data;
using TodoStates.Shared.CQRS;

namespace AspireTodo.ApiService.Todo.CreateToDo;

internal class CreateTodoCommandHandler(TicketContext context) : ICommandHandler<CreateTodoCommand, CreateTodoResponse>
{
    public async Task<CreateTodoResponse> Handle(CreateTodoCommand command, CancellationToken cancellationToken)
    {
        //todo: implement mapster
        var ticketItem = new TicketItem
        {
            Id = Guid.NewGuid(),
            Subject = command.Subject,
            Description = command.Description,
            CreatedDate = DateTime.UtcNow,
            CreatedBy = command.CreatedBy   
        };

        context.TicketItems.Add(ticketItem);
        await context.SaveChangesAsync(cancellationToken);

        return new CreateTodoResponse(ticketItem.Id);
    }
}
