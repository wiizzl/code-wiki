using SQLite;

namespace CodeWiki.Models;

public class Distro
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    
    public string? Name { get; set; }
    public string? Family { get; set; }
    public int? ReleaseYear { get; set; }
    public string? Description { get; set; }
    public string? ImageSource { get; set; }
    public string? MemeDescription { get; set; }
    public string? MemeSource { get; set; }
}