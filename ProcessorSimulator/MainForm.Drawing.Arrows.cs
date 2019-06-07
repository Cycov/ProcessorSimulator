using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessorSimulator
{
    public partial class MainForm
    {
        // +++++++++++++ ================= +++++++++++++
        private void DrawHorizontalCommandArrow(Graphics g, Control control, string value, double height)
        {
            DrawHorizontalCommandArrow(g, control, value, height, 0, value);
        }
        private void DrawHorizontalCommandArrow(Graphics g, Control control, string value, double height, int xOffset)
        {
            DrawHorizontalCommandArrow(g, control, value, height, xOffset, value);
        }
        private void DrawHorizontalCommandArrow(Graphics g, Control control, string value, double height, int xOffset, string command)
        {
            int x = control.Location.X + control.Width + xOffset;
            int y = (int)(control.Location.Y + control.Height * height);
            g.DrawArrow(GetPenThin(command), x + 20, y, x, y);
            g.DrawString(value, Font, Brushes.Black, x + 25, y - 5);
        }

        // +++++++++++++ ================= +++++++++++++
        private void DrawVerticalCommandArrow(Graphics g, Rectangle rect, DataBuses destinationBus, string value)
        {
            DrawVerticalCommandArrow(g, rect, destinationBus, value, 0.5, 0, value);
        }

        private void DrawVerticalCommandArrow(Graphics g, Rectangle rect, DataBuses destinationBus, string value, double width)
        {
            DrawVerticalCommandArrow(g, rect, destinationBus, value, width, 0, value);
        }

        private void DrawVerticalCommandArrow(Graphics g, Rectangle rect, DataBuses destinationBus, string text, double width, int yOffset, string command)
        {
            int x = (int)(rect.Location.X + rect.Width * width);
            int y = rect.Location.Y + rect.Height + yOffset;
            int destY = GetBusY(destinationBus);
            g.DrawArrow(GetPen(command, destinationBus), x, y, x, destY);
            g.DrawString(text, Font, Brushes.Black, x, destY - (destY - y) / 2);
        }

        // +++++++++++++ ================= +++++++++++++
        private void DrawVerticalCommandArrow(Graphics g, DataBuses sourceBus, Rectangle rect, string value)
        {
            DrawVerticalCommandArrow(g, sourceBus, rect, value, 0.5, 0, value);
        }

        private void DrawVerticalCommandArrow(Graphics g, DataBuses sourceBus, Rectangle rect, string value, double width)
        {
            DrawVerticalCommandArrow(g, sourceBus, rect, value, width, 0, value);
        }

        private void DrawVerticalCommandArrow(Graphics g, DataBuses sourceBus, Rectangle rect, string text, double width, int yOffset, string command, bool inverted = false)
        {
            int x = (int)(rect.Location.X + rect.Width * width);
            int y = rect.Location.Y + yOffset + (inverted ? rect.Height : 0);
            int sourceY = GetBusY(sourceBus);
            if (false)
            {
                int t = y;
                y = sourceY;
                sourceY = t;
            }
            g.DrawArrow(GetPen(command, sourceBus), x, sourceY, x, y);
            g.DrawString(text, Font, Brushes.Black, x, y - (y - sourceY) / 2 - 10);
        }

        // +++++++++++++ ================= +++++++++++++
        private void DrawVerticalCommandArrow(Graphics g, Rectangle sourceRect, Rectangle destRect, string value)
        {
            DrawVerticalCommandArrow(g, sourceRect, destRect, value, 0.5, 0, value);
        }

        private void DrawVerticalCommandArrow(Graphics g, Rectangle sourceRect, Rectangle destRect, string value, double width)
        {
            DrawVerticalCommandArrow(g, sourceRect, destRect, value, width, 0, value);
        }

        private void DrawVerticalCommandArrow(Graphics g, Rectangle sourceRect, Rectangle destRect, string text, double width, int yOffset, string command)
        {
            int x = (int)(sourceRect.Location.X + sourceRect.Width * width);
            int y = sourceRect.Location.Y + sourceRect.Height + yOffset;
            int destY = destRect.Y;
            g.DrawArrow(GetPenThin(command), x, y, x, destY);
            g.DrawString(text, Font, Brushes.Black, x, destY - (destY - y) / 2);
        }
    }
}
