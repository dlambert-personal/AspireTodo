using Mapster;
using TodoStates.CrossCutting.CQRS;

namespace AspireTodo.ApiService.Todo.CreateToDo;

public class CreateTodoEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/Todoitems",
                async (
                    CreateTodoRequest request,
                    [FromServices] IDispatcher dispatcher,
                    CancellationToken cancellationToken) =>
                {
                    var command = request.Adapt<CreateTodoCommand>();
                    var result = await dispatcher.Send<CreateTodoCommand, CreateTodoResponse>(command, cancellationToken);

                    return Results.Created($"/Customers/{result.Id}", result);
                })
            .WithName("CreateTodo")
            .Produces<CreateTodoResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create todo item")
            .WithDescription("Create todo item");
    }
}
