using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using System.Text.Json;

namespace Application.Services
{
    public class MousePositionService : IMousePositionService
    {
        private readonly IMousePositionRepository _repository;
        public MousePositionService(IMousePositionRepository repository) => _repository = repository;

        public async Task SaveAsync(List<MousePositionDto> positions)
        {
            if (positions == null || positions.Count == 0)
            {
                throw new ArgumentException("The list of positions cannot be empty.");
            }
            var entity = new MousePosition
            {
                Data = JsonSerializer.Serialize(positions),
                CreatedAt = DateTime.Now
            };
            await _repository.AddAsync(entity);
        }
    }
}
