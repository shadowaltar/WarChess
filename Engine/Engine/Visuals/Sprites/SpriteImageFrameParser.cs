using Engine.Models.Abstracts;

using SkiaSharp;

using static Engine.Visuals.Sprites.SpriteImageFrameParser.CornerData;

namespace Engine.Visuals.Sprites;
public class SpriteImageFrameParser
{
    public static void Parse(string path)
    {
        try
        {
            var bytes = System.IO.File.ReadAllBytes(path);
            var skBitmap = SKBitmap.Decode(bytes);
            var width = skBitmap.Width;
            var height = skBitmap.Height;
            var frames = ParseFrames(skBitmap);
            for (int i = 0; i < frames.Count; i++)
            {
                // set anchor to bottomMiddle
                FrameData frame = frames[i];
                frame.AnchorPoint = new Coordinate2D { X = frame.Width / 2, Y = frame.Height };
                Console.WriteLine(frame + ",");
            }
            Console.WriteLine($"Parsed sprite image frames from {path}: {width}x{height}, total pixels: {width * height}, frame count: {frames.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing sprite image frames from {path}: {ex.Message}");
        }
    }

    private static List<FrameData> ParseFrames(SKBitmap bitmap)
    {
        int width;
        int height;
        PixelData[] pixels;
        SortedSet<CornerData> corners = new SortedSet<CornerData>(new CornerDataComparer());
        unsafe
        {
            IntPtr pixelsPtr = bitmap.GetPixels();
            byte* bmpPtr = (byte*)pixelsPtr.ToPointer();

            int bytesPerPixel = bitmap.BytesPerPixel;
            width = bitmap.Width;
            height = bitmap.Height;

            pixels = new PixelData[height * width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int offset = (y * width + x) * bytesPerPixel;

                    // Access individual color components directly from the pointer
                    byte red = bmpPtr[offset + 0];
                    byte green = bmpPtr[offset + 1];
                    byte blue = bmpPtr[offset + 2];
                    byte alpha = bmpPtr[offset + 3];

                    SKColor pixelColor = new(red, green, blue, alpha);

                    var pixel = new PixelData(x, y, pixelColor);
                    pixels[y * width + x] = pixel;
                }
            }
        }


        for (int y = 1; y < height - 1; y++)
        {
            for (int x = 1; x < width - 1; x++)
            {
                var pixel = pixels[y * width + x];
                if (pixel.Color.Alpha != 0)
                    continue;

                var topPixel = pixels[(y - 1) * width + x];
                var bottomPixel = pixels[(y + 1) * width + x];
                var leftPixel = pixels[y * width + (x - 1)];
                var rightPixel = pixels[y * width + (x + 1)];
                if (topPixel.Color == SKColors.Black && leftPixel.Color == SKColors.Black)
                {
                    corners.Add(new CornerData(x, y, CornerType.TopLeft));
                }
                else if (topPixel.Color == SKColors.Black && rightPixel.Color == SKColors.Black)
                {
                    corners.Add(new CornerData(x, y, CornerType.TopRight));
                }
                else if (bottomPixel.Color == SKColors.Black && leftPixel.Color == SKColors.Black)
                {
                    corners.Add(new CornerData(x, y, CornerType.BottomLeft));
                }
                else if (bottomPixel.Color == SKColors.Black && rightPixel.Color == SKColors.Black)
                {
                    corners.Add(new CornerData(x, y, CornerType.BottomRight));
                }
            }
        }

        List<FrameData> frames = [];
        while (true)
        {
            var topLeft = corners.FirstOrDefault(c => c.CornerType == CornerType.TopLeft);
            if (topLeft == default)
            {
                // no more possible frames
                break;
            }
            var topRight = corners.FirstOrDefault(c => c.CornerType == CornerType.TopRight && c.Y == topLeft.Y && c.X > topLeft.X);
            if (topRight == default)
            {
                corners.Remove(topLeft);
                continue;
            }
            var bottomLeft = corners.FirstOrDefault(c => c.CornerType == CornerType.BottomLeft && c.X == topLeft.X && c.Y > topLeft.Y);
            if (bottomLeft == default)
            {
                corners.Remove(topLeft);
                continue;
            }
            var bottomRight = corners.FirstOrDefault(c => c.CornerType == CornerType.BottomRight && c.X == topRight.X && c.Y == bottomLeft.Y);
            if (bottomRight == default)
            {
                corners.Remove(topLeft);
                continue;
            }

            var frame = new FrameData(topLeft, topRight, bottomLeft, bottomRight);
            frames.Add(frame);
            corners.Remove(topLeft);
            corners.Remove(topRight);
            corners.Remove(bottomLeft);
            corners.Remove(bottomRight);
        }


        for (int i = 0; i < frames.Count; i++)
        {
            FrameData frame = frames[i];
            ShrinkFrame(ref frame, pixels, width);
            frames[i] = frame;
        }

        return frames;
    }

    private static void ShrinkFrame(ref FrameData frame, PixelData[] pixels, int width)
    {
        var topLeft = frame.TopLeft;
        var topRight = frame.TopRight;
        var bottomLeft = frame.BottomLeft;
        var bottomRight = frame.BottomRight;

        var left = topLeft.X;
        var right = topRight.X;
        var x = topLeft.X;
        var y = topLeft.Y;

        // remove transparent rows by scanning from top to bottom
        while (true)
        {
            var isTransparent = true;
            for (x = left; x <= right; x++)
            {
                var pixel = pixels[y * width + x];
                if (pixel.Color.Alpha != 0)
                {
                    isTransparent = false;
                    break;
                }
            }
            if (isTransparent)
            {
                y++;
                topLeft.Y = y;
                topRight.Y = y;
            }
            else
            {
                break;
            }
        }
        frame.TopLeft = topLeft;
        frame.TopRight = topRight;

        // from bottom to top
        y = bottomLeft.Y;
        while (true)
        {
            var isTransparent = true;
            for (x = left; x <= right; x++)
            {
                var pixel = pixels[y * width + x];
                if (pixel.Color.Alpha != 0)
                {
                    isTransparent = false;
                    break;
                }
            }
            if (isTransparent)
            {
                y--;
                bottomLeft.Y = y;
                bottomRight.Y = y;
            }
            else
            {
                break;
            }
        }
        frame.BottomLeft = bottomLeft;
        frame.BottomRight = bottomRight;

        // from left to right
        while (true)
        {
            var isTransparent = true;
            for (y = topLeft.Y; y <= bottomLeft.Y; y++)
            {
                var pixel = pixels[y * width + left];
                if (pixel.Color.Alpha != 0)
                {
                    isTransparent = false;
                    break;
                }
            }
            if (isTransparent)
            {
                left++;
                topLeft.X = left;
                bottomLeft.X = left;
            }
            else
            {
                break;
            }
        }
        frame.TopLeft = topLeft;
        frame.BottomLeft = bottomLeft;

        x = topRight.X;
        while (true)
        {
            var isTransparent = true;
            for (y = topRight.Y; y <= bottomRight.Y; y++)
            {
                var pixel = pixels[y * width + x];
                if (pixel.Color.Alpha != 0)
                {
                    isTransparent = false;
                    break;
                }
            }
            if (isTransparent)
            {
                x--;
                topRight.X = x;
                bottomRight.X = x;
            }
            else
            {
                break;
            }
        }
        frame.TopRight = topRight;
        frame.BottomRight = bottomRight;
    }

    public record struct PixelData(int X, int Y, SKColor Color);

    public record struct CornerData(int X, int Y, CornerType CornerType)
    {
        public int X { get; set; } = X;
        public int Y { get; set; } = Y;

        public class CornerDataComparer : IComparer<CornerData>
        {
            public int Compare(CornerData x, CornerData y)
            {
                int result = x.Y.CompareTo(y.Y);
                return result != 0 ? result : x.X.CompareTo(y.X);
            }
        }
    }

    public record struct FrameData(CornerData TopLeft, CornerData TopRight, CornerData BottomLeft, CornerData BottomRight)
    {
        public CornerData TopLeft { get; set; } = TopLeft;
        public CornerData TopRight { get; set; } = TopRight;
        public CornerData BottomLeft { get; set; } = BottomLeft;
        public CornerData BottomRight { get; set; } = BottomRight;

        public Coordinate2D AnchorPoint { get; set; }

        public int Width => TopRight.X - TopLeft.X;

        public int Height => BottomLeft.Y - TopLeft.Y;

        public override string ToString()
        {
            //return $"[({TopLeft.X},{TopLeft.Y}), ({TopRight.X},{TopRight.Y}), ({BottomLeft.X},{BottomLeft.Y}), ({BottomRight.X},{BottomRight.Y})]";
            return $"[ {TopLeft.X}, {TopLeft.Y}, {BottomRight.X}, {BottomRight.Y}, {AnchorPoint.X}, {AnchorPoint.Y} ]";
        }
    }

    public enum CornerType
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight
    }
}
