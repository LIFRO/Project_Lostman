namespace Backend.Models;

public class EditedApi
{
    public Int64 Id { get; set; }
    public string? Name { get; set; }

    public Int64? ParentId { get; set; }
    public ApiCatalog? Parent { get; set; }

    public string? Method { get; set; }
}
