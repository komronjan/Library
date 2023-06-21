using System.ComponentModel.DataAnnotations;

namespace WebApi.Dtos.Publisher;

public class PublisherBaseDto
{
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Address { get; set; }
    [MaxLength(50)]
    public string State { get; set; }
}
