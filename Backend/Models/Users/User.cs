namespace Backend.Models;

public class User : IUser
{
    public int Id { get; set; }
    public string Username {get; set; } = "";
    public string Password { get; set; } = "";
    public byte[] Salt { get; set; } = new byte[0];
    public List<ApiCatalog> Catalogs { get; set; } = new();
}
