using TodoStates.Shared.CQRS;
using TodoStates.Shared.Pagination;

namespace AspireTodo.ApiService.Ticket.GetTickets;
public class GetTicketsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Tickets", async ([AsParameters] PaginationRequest request,
                IQueryHandler<GetTicketsQuery, GetTicketsResponse> handler, CancellationToken cancellationToken) =>
        {
            var result = await handler.Handle(new GetTicketsQuery(request), cancellationToken);

            var response = result.Adapt<GetTicketsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetTickets")
        .Produces<GetTicketsResponse>()
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Tickets")
        .WithDescription("Get Tickets as a paginated list.");
    }
}
