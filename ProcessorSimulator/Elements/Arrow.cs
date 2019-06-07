using System.Drawing;

namespace ProcessorSimulator.Microprocessor.DrawnObjects
{
    class Arrow : Line
    {
        public Arrow(Point pt1, Point pt2) : base(pt1, pt2)
        {
        }

        public Arrow(Point pt1, Point pt2, Pen pen) : base(pt1, pt2, pen)
        {
        }

        public Arrow(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {
        }

        public Arrow(int x1, int y1, int x2, int y2, Pen pen) : base(x1, y1, x2, y2, pen)
        {
        }
    }
}
