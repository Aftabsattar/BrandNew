using Curate.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Curate.Application.DTO.Idea;

public class IdeaUpdateDto
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    [Required  ]
    public List<int> ProductId{ get; set; }
}