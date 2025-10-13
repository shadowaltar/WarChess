using Engine.Logic.Jobs.Ui;
using Engine.Utils;

namespace Engine.Logic.Jobs;
public class JobManager
{
    private readonly PubPollBuffer<UiEvent> uiEventPubPoller;
    private readonly PubPollBuffer<VisualJob> visualJobPubPoller;

    public JobManager()
    {
        uiEventPubPoller = new PubPollBuffer<UiEvent>(16);
    }

    public void Start()
    {
        uiEventPubPoller.Start();
    }

    public static void ScheduleAndInvokeAfter(int holdViewSec, Action invocation)
    {
    }

    public void ScheduleUiEvent(UiEventType type, int hotZoneId, object data)
    {
        uiEventPubPoller.Publish(uiEvent =>
        {
            uiEvent.Type = type;
            uiEvent.HotZoneId = hotZoneId;
            uiEvent.Data = data;
        });
    }

    public void PublishVisualJob(VisualJob job)
    {
        visualJobPubPoller.Publish(visualJob => visualJob.CopyFrom(job));
    }

    public int PollUiEvent()
    {
        return uiEventPubPoller.Poll(OnUiEventPolled);
    }

    public int PollVisualJob()
    {
        return visualJobPubPoller.Poll(OnVisualTaskPolled);
    }

    private bool OnUiEventPolled(UiEvent data, long sequence, bool endOfBatch)
    {
        Console.WriteLine(data);
        return true;
    }

    private bool OnVisualTaskPolled(VisualJob data, long sequence, bool endOfBatch)
    {
        if (!data.IsCompleted)
        {
            
        }
        return true;
    }
}
