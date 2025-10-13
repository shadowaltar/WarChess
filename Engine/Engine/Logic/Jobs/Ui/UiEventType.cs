namespace Engine.Logic.Jobs.Ui;
public enum UiEventType
{
    FingerTapped, // usually selection
    FingerDoubleTapped, // usually enter / show details / show commands
    FingerLongPressed, // usually enter / show details / show commands
    FingerLongPressedAndDragged, // usually select and move
    TwoFingerPinched, // usually zoom out
    TwoFingerSpreaded, // usually zoom in
    TwoFingerDragged, // usually pan
    TwoFingerRotated, // usually rotate
    FingerSwippedDown, // usually show context menu
    FingerSwippedUp, // usually show context menu
    MouseClicked,
    MouseDoubleClicked,
    MouseDragged,
    MouseRightButtonClicked,
    MouseRightButtonDoubleClicked,
    MouseRightButtonDragged,
    MouseHover,
    MouseMove,
    KeyDown,
    KeyUp,
    KeyPressed,
    KeyDoublePressed,
    KeyLongPressed
}
