using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentScheduler.infrastructure.Data;

namespace StudentScheduler.infrastructure.Abstractions
{
    public abstract class BaseEFRepository
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseEFRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
