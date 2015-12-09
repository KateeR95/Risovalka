using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;




namespace WpfApplication1
{
    internal class MyRectangle
    {
       private Rectangle rectan;
       private Guid name;

        public MyRectangle(Canvas canvas, bool dash)
        {
            rectan = new Rectangle
            {
                Stroke = Brushes.Black,
                StrokeThickness = 3,
                Fill = new SolidColorBrush(Colors.BlueViolet)
            };
            if (dash)
                rectan.StrokeDashArray = new DoubleCollection { 1, 1 };

            canvas.Children.Add(rectan);
        }


        public Rectangle Rectan()
        {
            return rectan;
        }

        public Guid Name
        {
            get { return name; }
            set
            {
                name = value;
                rectan.Tag = name;
            }
        }

        public double Width
        {
            get { return rectan.Width; }
            set
            {
                rectan.Width = value;
             }
        }
        public double Height
        {
            get { return rectan.Height; }
            set
            {
                rectan.Height = value;
             }
        }

        public double X
        {
            get { return Canvas.GetLeft(rectan); }
            set
            {
                Canvas.SetLeft(rectan, value);
              
            }
        }

        public double Y
        {
            get { return Canvas.GetTop(rectan); }
            set
            {
                Canvas.SetTop(rectan, value);
                
            }
        }

    }
}

