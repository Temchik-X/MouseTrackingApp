using Domain.Entities;
using Application.DTOs;
using System.Text.Json;

namespace Application.Interfaces
{
    public interface IMousePositionService
    {
        Task SaveAsync(List<MousePositionDto> positions);
    }
}
