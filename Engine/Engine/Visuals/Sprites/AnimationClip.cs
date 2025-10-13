namespace Engine.Visuals.Sprites;
public class AnimationClip
{
    public SpriteState State { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public Sprite[] Frames { get; set; }

    /// <summary>
    /// Given a sprite-state, this index array may look like [0,0,0,0,1,2,3,4]:
    /// it means that it would stay in frame 0 for 4 intervals then go through the rest of the frames
    /// </summary>
    public int[] AnimationFrameIndexes { get; set; }
    
    public int StartingFrameIndex { get; set; } = 0;

    public bool IsLooping { get; set; } = true;
}
