using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities;

public class BookEditor
{
    public string Isbn { get; set; }
    public int EditorId { get; set; }
    [ForeignKey("Isbn")]
    public virtual Book Book  { get; set; }
    public virtual Editor Editor { get; set; }
    
}