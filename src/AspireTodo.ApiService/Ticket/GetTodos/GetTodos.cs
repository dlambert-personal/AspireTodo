using TodoStates.Shared.CQRS;
using TodoStates.Shared.Pagination;

namespace AspireTodo.ApiService.Ticket.GetTickets;
public class GetTicketsQuery(PaginationRequest request) : IQuery<GetTicketsResponse>
{
    public PaginationRequest Request { get; } = request;
}
// todo: consider use of DTO here
public record GetTicketsResponse(PaginatedResult<TicketItem> Tickets);