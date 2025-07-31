using System.ComponentModel.DataAnnotations;

namespace VideoGameApi.Models
{
    public class VideoGame
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(50, ErrorMessage = "Platform cannot exceed 50 characters.")]
        public string Platform { get; set; } = string.Empty;

        [Required(ErrorMessage = "Developer is required.")]
        [MaxLength(50, ErrorMessage = "Developer cannot exceed 50 characters.")]
        public string Developer { get; set; } = string.Empty;

        [Required(ErrorMessage = "Publisher is required.")]
        [MaxLength(50, ErrorMessage = "Publisher cannot exceed 50 characters.")]
        public string Publisher { get; set; } = string.Empty;
    }
}
