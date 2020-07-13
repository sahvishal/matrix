namespace Falcon.App.Core.Application.Impl
{
    public struct RectangleDimesion
    {
        public int PositionX;
        public int PositionY;
        public int Width;
        public int Heigth;

        public RectangleDimesion(int x, int y, int width, int height)
        {
            PositionX = x;
            PositionY = y;
            Width = width;
            Heigth = height;
        }

    }
}
