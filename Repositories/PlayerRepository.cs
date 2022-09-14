using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.Abstract;
using Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class PlayerRepository : DbRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(DbContext context) : base(context)
        {
        }
    }
}
