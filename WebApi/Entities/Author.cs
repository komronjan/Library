using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;

public class Author
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Ssn { get; set; }
    [MaxLength(50)]
    public string Firstname { get; set; }
    [MaxLength(50)]
    public string Lastname { get; set; }
    [MaxLength(50)]
    public string Phone { get; set; }
    [MaxLength(100)]
    public string Address { get; set; }
    [MaxLength(50)]
    public string City { get; set; }
    [MaxLength(50)]
    public string State { get; set; }
    [MaxLength(50)]
    public string Zip { get; set; }
    public virtual ICollection<BookAuthor> BookAuthors { get; set; }

}