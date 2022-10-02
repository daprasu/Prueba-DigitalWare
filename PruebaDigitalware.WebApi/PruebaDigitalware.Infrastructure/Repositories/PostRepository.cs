using Microsoft.EntityFrameworkCore;
using PruebaDigitalware.Core.Entities;
using PruebaDigitalware.Core.Interfaces;
using PruebaDigitalware.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDigitalware.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IsaBDContext _context;

        public PostRepository(IsaBDContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Venta>> GetPosts()
        {
            var posts = await _context.Venta.ToListAsync();
            return posts;
        }
    }
}
