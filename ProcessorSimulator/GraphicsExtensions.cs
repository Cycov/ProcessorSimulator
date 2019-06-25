//-----------------------------------------------------------------------

// <copyright file="GraphicsExtensions.cs" author="Circa Dragos">

//     Copyright (c) Circa Dragos. All rights reserved.

// </copyright>

//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessorSimulator
{
    public static class GraphicsExtensions
    {
        public static void DrawArrow(this Graphics g, Pen pen, Point p1, Point p2)
        {
            Pen p = pen.Clone() as Pen;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(p, p1, p2);
        }
        public static void DrawArrow(this Graphics g, Pen pen, int x1, int y1, int x2, int y2)
        {

            Pen p = pen.Clone() as Pen;
            p.StartCap = System.Drawing.Drawing2D.LineCap.Flat;
            p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(p, x1, y1, x2, y2);
        }

        public static void DrawALU(this Graphics g, Pen pen, Rectangle bounds)
        {
            int tenPercentOfWidth = bounds.Width / 10;
            int twentyPercentOfHeight = bounds.Height / 5;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            Point[] points = new Point[] {
                new Point(bounds.X + bounds.Width/2 - tenPercentOfWidth, bounds.Y+ bounds.Height),
                new Point(bounds.X, bounds.Y + bounds.Height),
                new Point(bounds.X + tenPercentOfWidth * 3, bounds.Y),
                new Point(bounds.X + bounds.Width - tenPercentOfWidth * 3, bounds.Y),
                new Point(bounds.X + bounds.Width, bounds.Y + bounds.Height),
                new Point(bounds.X + bounds.Width/2 + tenPercentOfWidth, bounds.Y+ bounds.Height),
                new Point(bounds.X + bounds.Width/2, bounds.Y + bounds.Height - twentyPercentOfHeight),
                new Point(bounds.X + bounds.Width/2 - tenPercentOfWidth, bounds.Y+ bounds.Height)
            };
            path.AddLines(points);
            path.CloseFigure();
            g.DrawPath(pen, path);
        }
    }
}
