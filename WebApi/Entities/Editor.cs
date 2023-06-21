using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities;

public class Editor
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Ssn { get; set; }
    [MaxLength(50)]
    public string Firstname { get; set; }
    [MaxLength(50)]
    public string Lastname { get; set; }
    [MaxLength(50)]
    public string Phone { get; set; }
    [MaxLength(50)]
    public string EditorPosition { get; set; }
    public decimal Salary { get; set; }
    public virtual ICollection<BookEditor> BookEditors { get; set; }
}