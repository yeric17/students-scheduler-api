using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.Domain.Entities
{
    public class Subject
    {
        [Key]
        [StringLength(50)]
        public required string SubjectId { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        [Range(1, 10)]
        public int Credits { get; set; }
    }
}
