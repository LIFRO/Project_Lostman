namespace Backend.Models;

public interface IUser
{
    int Id { get; set; }
    string Username {get; set; }
    string Password { get; set; }
    byte[] Salt { get; set; }
    List<ApiCatalog> Catalogs { get; set; }
}
