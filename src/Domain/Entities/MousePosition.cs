namespace Domain.Entities;

public class MousePosition
{
    public int Id { get; set; }
    public string Data { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}