using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorHybrid.Model.Entities;
public record Todo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; init; } = 0;
    public string Title { get; init; } = "";
    public bool IsDone { get; init; } = false;
}
