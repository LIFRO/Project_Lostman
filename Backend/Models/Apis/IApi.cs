namespace Backend.Models;

public interface IApi
{
    int Id{ get; set; }
    string UserId { get; set; }
    string Name { get; set; }
    Guid? ParentId { get; set; }
    ApiCatalog? Parent { get; set; }
}
