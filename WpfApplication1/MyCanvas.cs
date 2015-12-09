using System;
using System.Collections.Generic;
using System.Linq;


namespace WpfApplication1
{
    class MyCanvas
    {
        public int OX;
        public int OY;
        private Guid name; 
        private int side; 

        public readonly List<MyRectangle> MRectangle;

        public MyCanvas()
        {
            MRectangle = new List<MyRectangle>();
        }

        public Guid GetName()
        {
            return name;
        }

        public int GetSide()
        {
            return side;
        }

        public bool IsInto(int MX, int mouseY)
        {
            for (int i = MRectangle.Count - 1; i >= 0; i--)
            {
                MyRectangle rect = MRectangle[i];
                if ((rect.X < MX) && (rect.X + rect.Width > MX) && (rect.Y < mouseY) && (rect.Y + rect.Height > mouseY))
                {
                    name = rect.Name;
                    if ((MX >= rect.X) && (MX <= rect.X)) ;
                    else if ((MX >= rect.X + rect.Width) && (MX <= rect.X + rect.Width)) ;
                    else if ((mouseY >= rect.Y) && (mouseY <= rect.Y)) ;
                    else if ((mouseY >= rect.Y + rect.Height) && (mouseY <= rect.Y + rect.Height)) ;
                    else side = 0;
                    return true;
                }
            }
            side = 0;
            name = Guid.Empty;
            return false;
        }

        public void MoveRect(int MX, int MY) 
        {
            if (MRectangle.Any(s => s.Name == name))
            {
                MRectangle.First(s => s.Name == name).X = MX - OX;
                MRectangle.First(s => s.Name == name).Y = MY - OY;
            }
        }

        public void ResizeRect(int MX, int MY) 
        {
            switch (side)
            {
                case 1:
                    MRectangle.First(s => s.Name == name).X = MX;
                    MRectangle.First(s => s.Name == name).Width = OX - MRectangle.First(s => s.Name == name).X;
                    break;
                case 2:
                    MRectangle.First(s => s.Name == name).Y = MY;
                    MRectangle.First(s => s.Name == name).Height = OY - MRectangle.First(s => s.Name == name).Y;
                    break;
                case 3:
                    MRectangle.First(s => s.Name == name).Width = MX - MRectangle.First(s => s.Name == name).X;
                    break;
                case 4:
                    MRectangle.First(s => s.Name == name).Height = MY - MRectangle.First(s => s.Name == name).Y;
                    break;
            }
        }

        public void DrawRect(int MX, int MY, MyRectangle rect) 
        {
            if (MX > OX)
            {
                rect.Width = MX - OX;
                rect.X = OX;
            }
            else
            {
                rect.Width = OX - MX;
                rect.X = MX;
            }

            if (MY > OY)
            {
                rect.Height = MY - OY;
                rect.Y = OY;
            }
            else
            {
                rect.Height = OY - MY;
                rect.Y = MY;
            }
        }

        public void AddRect(MyRectangle rect)
        {
            MRectangle.Add(rect);
        }
    }
}
