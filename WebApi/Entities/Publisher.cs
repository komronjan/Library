using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;

public class Publisher
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Address { get; set; }
    [MaxLength(50)]
    public string State { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}