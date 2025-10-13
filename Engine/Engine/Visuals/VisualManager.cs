using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Logic.Jobs;

namespace Engine.Visuals;
public class VisualManager
{
    public static void ShowView(string viewId, double fadeInSpeedSec)
    {

    }
    public static void HideView(string viewId, double fadeOutSpeedSec)
    {

    }

    public static IEvent ShowThenHide(string viewId, int holdViewSec, double fadingSec)
    {
        ShowView(viewId, fadingSec);
        JobManager.ScheduleAndInvokeAfter(holdViewSec, ()=>HideView(viewId, fadingSec));
        return null;
    }
}
