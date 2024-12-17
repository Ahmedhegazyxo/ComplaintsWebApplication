namespace Base;

public class User : BaseEntity
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
    public bool IsAdmin { get; set; }
    public string Role { get; set; }
}
