using System.ComponentModel.DataAnnotations;

namespace Coffee_House_Aya.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        [StringLength(8,MinimumLength =6,ErrorMessage ="Password should be 6-8 char" )]
        public string? password { get; set; }
        public string? Gender { get; set; }
        [Range(18,70)]
        public int? Age { get; set; }
        [Display(Name = "Image")]
        public string? UImage { get; set; }
        public int RoleId { get; set; }
        public Role? Role { get; set; }

    }
}
