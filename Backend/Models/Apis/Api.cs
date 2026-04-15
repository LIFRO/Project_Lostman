namespace Backend.Models;

public class Api : IApi
{
    public int Id{ get; set; }
    public string UserId { get; set; } = "";
    public string Name { get; set; } = "";
    public Guid? ParentId { get; set; }
    public ApiCatalog? Parent { get; set; }
}
