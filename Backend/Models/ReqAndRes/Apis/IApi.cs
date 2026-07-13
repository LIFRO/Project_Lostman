namespace Backend.Models;

public interface IApi
{
    Int64 Id{ get; set; }
    string Name { get; set; }
    Int64? ParentId { get; set; }
    ApiCatalog? Parent { get; set; }
    public string Method { get; set; }
}
