namespace Engine.Logic.Actions;

public class VisualAction(string Name, params string[] Args) : BasicAction(Name, Args)
{
    public static class Names
    {
        public const string HideView = "hideView";
        public const string ShowView = "showView";
        public const string ToCenter = "toCenter";
        public const string PlayVideo = "playVideo";
        public const string SkipVideo = "skipVideo";
    }
}

public class HideViewAction(params string[] Args) : VisualAction(VisualAction.Names.HideView, Args)
{

}


public class ShowViewAction(params string[] Args) : VisualAction(VisualAction.Names.ShowView, Args)
{

}
