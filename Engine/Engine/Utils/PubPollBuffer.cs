using Disruptor;
using Disruptor.Dsl;

namespace Engine.Utils;
public class PubPollBuffer<T> where T : class, new()
{
    private readonly Disruptor<T> disruptor;
    private readonly RingBuffer<T> ringBuffer;
    private readonly EventPoller<T> eventPoller;

    public PubPollBuffer(int predefinedSize)
    {
        var producerType = ProducerType.Single;
        var taskScheduler = TaskScheduler.Default;
        var waitStrategy = new YieldingWaitStrategy();
        disruptor = new(() => new T(), predefinedSize, taskScheduler, producerType, waitStrategy);
        ringBuffer = disruptor.RingBuffer;
        eventPoller = ringBuffer.NewPoller();
        ringBuffer.AddGatingSequences(eventPoller.Sequence);
    }

    public void Start()
    {
        disruptor.Start();
    }

    public void Publish(Action<T> modifyAction)
    {
        long seq = ringBuffer.Next();
        try
        {
            T e = ringBuffer.ClaimAndGetPreallocated(seq);
            modifyAction.Invoke(e);
        }
        finally
        {
            ringBuffer.Publish(seq);
        }
    }

    public int Poll(EventPoller.Handler<T> handler)
    {
        var state = eventPoller.Poll(handler);
        if (state == EventPoller.PollState.Processing)
        {
            return 1;
        }
        return 0;
    }
}
