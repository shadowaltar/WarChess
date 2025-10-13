using Engine.Logic.Jobs;
using Engine.Logic.Jobs.Ui;

using NUnit.Framework;

namespace EngineTests.Logic.Events;

[TestFixture()]
public class JobManagerTests
{
    [Test()]
    public void EventManagerTest()
    {
        var em = new JobManager();
        em.ScheduleUiEvent(UiEventType.FingerLongPressed, 101, "string 1");
        em.ScheduleUiEvent(UiEventType.FingerLongPressed, 102, "string 2");

        em.PollUiEvent();
        em.PollUiEvent();
    }

    [Test()]
    public void ScheduleAndInvokeAfterTest()
    {

    }

    [Test()]
    public void ScheduleUiEventTest()
    {

    }

    [Test()]
    public void PollUiEventTest()
    {

    }
}