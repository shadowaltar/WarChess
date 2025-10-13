using Engine.Logic.Jobs;
using Engine.Logic.States;
using Engine.Models.Supportive;
using Engine.Visuals;

namespace Engine.Logic;
public class MainLoop
{
    private ServiceState serviceState = ServiceState.Initializing;
    private DateTime previousTimestamp;
    private int minFrameTimeMs;
    private StateMachines stateMachines;
    private StateMachine mainStateMachine;
    private readonly JobManager jobManager;
    private readonly Ui ui;

    public MainLoop()
    {
        jobManager = new JobManager();
        ui = new Ui();
    }

    public void Start()
    {
        // show loading splash screen
        Initialize();
        ShowTitleScreen();
        while (CanExecuteNextFrame())
        {
            jobManager.PollUiEvent();
            var changes = jobManager.PollVisualJob();
            if (changes > 0)
            {
                ui.Redraw();
            }
        }
        Shutdown();
    }

    private void ShowTitleScreen()
    {
        VisualManager.ShowThenHide(TitleScreen.ViewId, 3, 0.5);
    }

    private void ProcessInput()
    {
        throw new NotImplementedException();
    }

    private void UpdateView()
    {
        throw new NotImplementedException();
    }

    private void Shutdown()
    {
        throw new NotImplementedException();
    }

    private void Initialize()
    {
        stateMachines = new StateMachines();
        stateMachines.Initialize();
        mainStateMachine = stateMachines.Machines["TitleScreen"];
        serviceState = ServiceState.Running;
        previousTimestamp = DateTime.UtcNow;
        minFrameTimeMs = 1000 / 500;
    }

    private bool CanExecuteNextFrame()
    {
        if (serviceState != ServiceState.Running)
            return false;

        var now = DateTime.UtcNow;
        if ((now - previousTimestamp).TotalMilliseconds > minFrameTimeMs)
        {
            previousTimestamp = now;
            return true;
        }
        return false;
    }
}
