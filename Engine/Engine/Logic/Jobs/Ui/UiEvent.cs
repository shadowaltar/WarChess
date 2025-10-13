using Engine.Models.Abstracts;

namespace Engine.Logic.Jobs.Ui;

public class UiEvent : IEvent
{
    public UiEventType Type { get; set; }
    public int HotZoneId { get; set; }
    public Coordinate2D Coordinate { get; set; }
    public Coordinate2D Coordinate2 { get; set; }
    public Coordinate2D ToCoordinate { get; set; }
    public Coordinate2D ToCoordinate2 { get; set; }
    public double PressDuration { get; set; }
    public object Data { get; set; }
}