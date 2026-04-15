namespace Backend.Models;

public interface IApiCatalog
{
    int Id { get; set; }
    string User { get; set; }
    string Name { get; set; }
    List<Api> Apis { get; set; }
    List<ApiCatalog> Children { get; set; }
    List<ApiCatalog> Parent { get; set; }
}