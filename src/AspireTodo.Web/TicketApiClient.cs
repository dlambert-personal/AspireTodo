using AspireTodo.Web.Components.Pages;

namespace AspireTodo.Web;

public class TicketApiClient(HttpClient httpClient)
{
    public async Task<Ticket[]> GetTicketsAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<Ticket>? tickets = null;
        await foreach (var ticket in httpClient.GetFromJsonAsAsyncEnumerable<Ticket>("/tickets", cancellationToken))
        {
            if (tickets?.Count >= maxItems)
            {
                break;
            }
            if (ticket is not null)
            {
                tickets ??= [];
                tickets.Add(ticket);
            }
        }

        return tickets?.ToArray() ?? [];
    }
}

public record Ticket(DateTime CreatedDate, string Subject, string Description, string CreatedBy)
{
    
}
