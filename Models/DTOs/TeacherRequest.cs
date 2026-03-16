using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Models.DTOs
{
    public class TeacherRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name must be between 2 and 100 characters", MinimumLength = 2)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(100, ErrorMessage = "Subject must be between 2 and 100 characters", MinimumLength = 2)]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Qualification is required")]
        [StringLength(200, ErrorMessage = "Qualification must be between 2 and 200 characters", MinimumLength = 2)]
        public string Qualification { get; set; } = string.Empty;

        [Required(ErrorMessage = "Joining date is required")]
        public DateTime JoiningDate { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
