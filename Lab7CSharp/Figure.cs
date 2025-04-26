using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7CSharp
{
    abstract class Figure
    {
        public int X, Y;         
        public Color Color;      
        public string Text;
        public abstract void Draw(Graphics g);
        public abstract void Move(int dx, int dy);
    }

    class Square : Figure
    {
        public int Size;

        public Square(int x, int y, Color color, string text, int size)
        {
            X = x;
            Y = y;
            Color = color;
            Text = text;
            Size = size;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 2);
            g.DrawRectangle(pen, X, Y, Size, Size);
            g.DrawString(Text, SystemFonts.DefaultFont, Brushes.Black, X + Size / 4, Y + Size / 4);
        }

        public override void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

    class Rectangle : Figure
    {
        public int Width, Height;

        public Rectangle(int x, int y, Color color, string text, int width, int height)
        {
            X = x;
            Y = y;
            Color = color;
            Text = text;
            Width = width;
            Height = height;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 2);
            g.DrawRectangle(pen, X, Y, Width, Height);
            g.DrawString(Text, SystemFonts.DefaultFont, Brushes.Black, X + Width / 4, Y + Height / 4);
        }

        public override void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

    class Triangle : Figure
    {
        public int Size;

        public Triangle(int x, int y, Color color, string text, int size)
        {
            X = x;
            Y = y;
            Color = color;
            Text = text;
            Size = size;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 2);
            Point[] points = {
            new Point(X, Y - Size / 2),
            new Point(X - Size / 2, Y + Size / 2),
            new Point(X + Size / 2, Y + Size / 2)
        };
            g.DrawPolygon(pen, points);
            g.DrawString(Text, SystemFonts.DefaultFont, Brushes.Black, X - 10, Y);
        }

        public override void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }

    class Circle : Figure
    {
        public int Radius;

        public Circle(int x, int y, Color color, string text, int radius)
        {
            X = x;
            Y = y;
            Color = color;
            Text = text;
            Radius = radius;
        }

        public override void Draw(Graphics g)
        {
            Pen pen = new Pen(Color, 2);
            g.DrawEllipse(pen, X - Radius, Y - Radius, 2 * Radius, 2 * Radius);
            g.DrawString(Text, SystemFonts.DefaultFont, Brushes.Black, X - Radius / 2, Y - Radius / 2);
        }

        public override void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }
}
