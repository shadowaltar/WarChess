namespace Engine.Logic.Jobs;

/// <summary>
/// Events are created elsewhere, indicating something happened. It will be processed in a busy loop.
/// Types are: UI event (touch, drag, keyboard, mouse), scheduled event, and other actions wrapped in events.
/// </summary>
public interface IEvent
{
}
