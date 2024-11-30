using System.ComponentModel.DataAnnotations;

namespace StudentScheduler.Domain.Entities
{
    public class Permission
    {
        [Key]
        [StringLength(50)]
        public required string PermissionId { get; set; }

        
        public required string PermissionName { get; set; }
    }
}
