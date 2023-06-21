using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos.Editor;

public class EditorBaseDto
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
}
