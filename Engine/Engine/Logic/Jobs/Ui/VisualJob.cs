using Engine.Utils;

namespace Engine.Logic.Jobs.Ui;
public class VisualJob : IJob, ICopyable<VisualJob>
{
    public bool IsCompleted { get; set; } = false;
    public int JobId { get; set; }
    public VisualJobType Type { get; set; }
    public object Data { get; set; }

    public void CopyFrom(VisualJob other)
    {
        JobId = other.JobId;
        Type = other.Type;
        Data = other.Data;
    }
}

