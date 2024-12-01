using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScheduler.infrastructure.Abstractions
{
    public interface IClaimsHelper
    {
        List<string>? GetRoles();
        string? GetUserId();
    }
}
