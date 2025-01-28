using Domain.Entities;
using Application.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MousePositionRepository : IMousePositionRepository
    {
        private readonly ApplicationDbContext _context;
        public MousePositionRepository(ApplicationDbContext context) => _context = context;

        public async Task AddAsync(MousePosition position)
        {
            await _context.MousePositions.AddAsync(position);
            await _context.SaveChangesAsync();
        }
    }
}
