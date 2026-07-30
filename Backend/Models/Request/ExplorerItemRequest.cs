using System.ComponentModel.DataAnnotations;

namespace Backend.Models;

public class ExplorerItemRequest()
{
    [Required]
    public Int64? Id { get; set; }
    public List<Api>? Api { get; set; }
    public List<ApiCatalog>? Catalog { get; set; }
}
