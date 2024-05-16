using System.ComponentModel.DataAnnotations;

namespace Bokhandel.ViewModels;

public class AddRoleViewModel
{
    [Microsoft.Build.Framework.Required]
    [Display(Name = "Role")]
    public string RoleName { get; set; }
}