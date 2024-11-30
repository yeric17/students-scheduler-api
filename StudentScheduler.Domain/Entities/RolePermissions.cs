using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace StudentScheduler.Domain.Entities
{
    public class RolePermissions
    {
        [Key]
        [StringLength(50)]
        public required string RolePermissionsId { get; set; }
        public IdentityRole IdentityRole { get; set; }
        public Permission Permissions { get; set; }
        
        public required string IdentityRoleId { get; set; }
        public required string PermissionId { get; set; }
    }
}
