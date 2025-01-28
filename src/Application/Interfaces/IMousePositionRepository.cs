using Domain.Entities;
namespace Application.Interfaces
{
    public interface IMousePositionRepository
    {
        Task AddAsync(MousePosition position);
    }
}
