namespace Backend.Models;

public class ExplorerItemRequest()
{
    public int Id { get; set; }
    public List<Api>? Api { get; set; }
    public List<ApiCatalog>? Catalog { get; set; }
}
