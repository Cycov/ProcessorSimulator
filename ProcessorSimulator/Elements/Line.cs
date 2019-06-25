//-----------------------------------------------------------------------

// <copyright file="Line.cs" author="Circa Dragos">

//     Copyright (c) Circa Dragos. All rights reserved.

// </copyright>

//-----------------------------------------------------------------------

using System.Drawing;

namespace ProcessorSimulator.Microprocessor.DrawnObjects
{
    class Line
    {
        public Point pt1, pt2;
        public Pen pen;
        public Line(Point pt1, Point pt2)
        {
            this.pt1 = pt1;
            this.pt2 = pt2;
        }
        public Line(int x1, int y1, int x2, int y2)
        {
            pt1 = new Point(x1, y1);
            pt2 = new Point(x2, y2);
        }
        public Line(Point pt1, Point pt2, Pen pen)
        {
            this.pt1 = pt1;
            this.pt2 = pt2;
            this.pen = pen;
        }
        public Line(int x1, int y1, int x2, int y2, Pen pen)
        {
            pt1 = new Point(x1, y1);
            pt2 = new Point(x2, y2);
            this.pen = pen;
        }
    }
}
