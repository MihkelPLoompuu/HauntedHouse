using System.ComponentModel.DataAnnotations;

namespace HauntedHouse.Models.Accounts
{
    public class AddPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Type new password here:")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Type it again to confirm:")]
        [Compare("NewPassword" , ErrorMessage ="The new password and its confirmation do not match. Plase retry.")]
        public string ConfirmPassword { get; set; }
    }
}
