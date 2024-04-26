namespace ApiBookStore.Comunication.Request;

public class RequestRegisterBook
{
    public int Id { get; set; }
    public string Title {  get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public string Amount { get; set; } = string.Empty;

}
