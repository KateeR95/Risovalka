using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;



namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private MyCanvas _canvas;
        private bool dash;
        private bool figure;

        public MainWindow()
        {
            InitializeComponent();
            _canvas = new MyCanvas();

        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            int MX = (int)Mouse.GetPosition(Canvas1).X;
            int MY = (int)Mouse.GetPosition(Canvas1).Y;


            if ((e.LeftButton == MouseButtonState.Pressed))
            {
                if (figure)
                {
                    if (_canvas.GetName() != Guid.Empty)
                    {
                        if (_canvas.MRectangle.Any(s => s.Name == _canvas.GetName()))
                        {
                            if (_canvas.GetSide() == 0)
                            {
                                _canvas.MoveRect(MX, MY);
                            }
                            else
                            {
                                _canvas.ResizeRect(MX, MY);
                            }
                        }
                    }
                    else
                    {
                        _canvas.DrawRect(MX, MY, _canvas.MRectangle.Last());
                    }
                }
               
            }

            
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            int MX = (int)Mouse.GetPosition(Canvas1).X;
            int MY = (int)Mouse.GetPosition(Canvas1).Y;

            if (figure)
            {
                if (_canvas.IsInto(MX, MY))
                {
                    if (_canvas.MRectangle.Any(s => s.Name == _canvas.GetName()))
                    {
                        MyRectangle temp = _canvas.MRectangle.First(s => s.Name == _canvas.GetName());

                        if (_canvas.GetSide() == 0)
                        {
                            _canvas.OX = MX - (int)temp.X;
                            _canvas.OY = MY - (int)temp.Y;
                        }
                        else
                        {
                            _canvas.OX = (int)(temp.Width + temp.X);
                            _canvas.OY = (int)(temp.Height + temp.Y);
                        }
                    }
                }
                else
                {
                    _canvas.OX = MX;
                    _canvas.OY = MY;
                    _canvas.AddRect(new MyRectangle(Canvas1, dash));
                }
            }
            else
            {
                if (_canvas.IsInto(MX, MY))
                {
                    _canvas.OX = MX;
                    _canvas.OY = MY;

               }
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void RadioType_Checked(object sender, RoutedEventArgs e)
        {
            //dash = !dash;
        }

      private void RadioFigure_Checked(object sender, RoutedEventArgs e)
        {
            figure = !figure;
        }

    }
}
