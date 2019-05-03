using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GameWFP
{
    /// <summary>
    /// Stores information for each piece on the board
    /// </summary>
    public class Pawn
    {
        Image i;

        public PlayerColor Color { get; }

        public FieldLocation Location { get; set; }

        /// <summary>
        /// Constructor for objects of type pawn
        /// </summary>
        /// <param name="color"></param>
        /// <param name="position"></param>
        public Pawn(PlayerColor color, int position, Canvas fieldCanvas)
        {
            Color = color;
            i = new Image();

            BitmapImage bi = new BitmapImage();
            bi.BeginInit();

            if (color == PlayerColor.green)
            {
                Location = new FieldLocation(FieldArea.GreenHome, position);
                bi.UriSource = new Uri("pack://application:,,,/Images/green.png");
            }
            else if (color == PlayerColor.yellow)
            {
                Location = new FieldLocation(FieldArea.YellowHome, position);
                bi.UriSource = new Uri("pack://application:,,,/Images/yellow.png");
            }
            else if (color == PlayerColor.blue)
            {
                Location = new FieldLocation(FieldArea.BlueHome, position);
                bi.UriSource = new Uri("pack://application:,,,/Images/blue.png");
            }
            else if (color == PlayerColor.red)
            {
                Location = new FieldLocation(FieldArea.RedHome, position);
                bi.UriSource = new Uri("pack://application:,,,/Images/red.png");
            }
            else
                throw new Exception("Invalid color for pawn.");

            bi.DecodePixelWidth = 22;
            bi.EndInit();
            i.Source = bi;

            fieldCanvas.Children.Add(i);
        }

        /// <summary>
        /// Converts the location of a piece to grid coordinates
        /// </summary>
        /// <returns></returns>
        public Point GridCoords()
        {
            Point coords = new Point();

            if (Location.Area == FieldArea.GreenHome)
            {
                if (Location.Position == 0)
                {
                    coords.X = 138;
                    coords.Y = 92;
                }
                if (Location.Position == 1)
                {
                    coords.X = 183;
                    coords.Y = 138;
                }
                if (Location.Position == 2)
                {
                    coords.X = 138;
                    coords.Y = 180;
                }
                if (Location.Position == 3)
                {
                    coords.X = 95;
                    coords.Y = 138;
                }
            }
            if (Location.Area == FieldArea.YellowHome)
            {
                if (Location.Position == 0)
                {
                    coords.X = 528; // original 138
                    coords.Y = 92;
                }
                if (Location.Position == 1)
                {
                    coords.X = 573;
                    coords.Y = 138;
                }
                if (Location.Position == 2)
                {
                    coords.X = 528;
                    coords.Y = 180;
                }
                if (Location.Position == 3)
                {
                    coords.X = 485;
                    coords.Y = 138;
                }
            }
            if (Location.Area == FieldArea.BlueHome)
            {
                if (Location.Position == 0)
                {
                    coords.X = 528; // original 138
                    coords.Y = 492;
                }
                if (Location.Position == 1)
                {
                    coords.X = 573;
                    coords.Y = 538;
                }
                if (Location.Position == 2)
                {
                    coords.X = 528;
                    coords.Y = 580;
                }
                if (Location.Position == 3)
                {
                    coords.X = 485;
                    coords.Y = 538;
                }
            }
            if (Location.Area == FieldArea.RedHome)
            {
                if (Location.Position == 0)
                {
                    coords.X = 138;
                    coords.Y = 492;
                }
                if (Location.Position == 1)
                {
                    coords.X = 183;
                    coords.Y = 538;
                }
                if (Location.Position == 2)
                {
                    coords.X = 138;
                    coords.Y = 580;
                }
                if (Location.Position == 3)
                {
                    coords.X = 95;
                    coords.Y = 538;
                }
            }
            if (Location.Area == FieldArea.YellowFinish)
            {
                if (Location.Position == 1)
                {
                    coords.X = 338;
                    coords.Y = 72;
                }
                if (Location.Position == 2)
                {
                    coords.X = 338;
                    coords.Y = 115;
                }
                if (Location.Position == 3)
                {
                    coords.X = 338;
                    coords.Y = 158;
                }
                if (Location.Position == 4)
                {
                    coords.X = 338;
                    coords.Y = 201;
                }
                if (Location.Position == 5)
                {
                    coords.X = 338;
                    coords.Y = 244;
                }
                if (Location.Position == 6)
                {
                    coords.X = 338;
                    coords.Y = 287;
                }
            }
            if (Location.Area == FieldArea.BlueFinish)
            {
                if (Location.Position == 1)
                {
                    coords.X = 592;
                    coords.Y = 338;
                }
                if (Location.Position == 2)
                {
                    coords.X = 549;
                    coords.Y = 338;
                }
                if (Location.Position == 3)
                {
                    coords.X = 506;
                    coords.Y = 338;
                }
                if (Location.Position == 4)
                {
                    coords.X = 463;
                    coords.Y = 338;
                }
                if (Location.Position == 5)
                {
                    coords.X = 420;
                    coords.Y = 338;
                }
                if (Location.Position == 6)
                {
                    coords.X = 387;
                    coords.Y = 338;
                }
            }
            if (Location.Area == FieldArea.RedFinish)
            {
                if (Location.Position == 1)
                {
                    coords.X = 338;
                    coords.Y = 605;
                }
                if (Location.Position == 2)
                {
                    coords.X = 338;
                    coords.Y = 562;
                }
                if (Location.Position == 3)
                {
                    coords.X = 338;
                    coords.Y = 519;
                }
                if (Location.Position == 4)
                {
                    coords.X = 338;
                    coords.Y = 471;
                }
                if (Location.Position == 5)
                {
                    coords.X = 338;
                    coords.Y = 428;
                }
                if (Location.Position == 5)
                {
                    coords.X = 338;
                    coords.Y = 385;
                }
            }
            if (Location.Area == FieldArea.GreenFinish)
            {
                if (Location.Position == 1)
                {
                    coords.X = 75;
                    coords.Y = 338;
                }
                if (Location.Position == 2)
                {
                    coords.X = 118;
                    coords.Y = 338;
                }
                if (Location.Position == 3)
                {
                    coords.X = 161;
                    coords.Y = 338;
                }
                if (Location.Position == 4)
                {
                    coords.X = 204;
                    coords.Y = 338;
                }
                if (Location.Position == 5)
                {
                    coords.X = 247;
                    coords.Y = 338;
                }
                if (Location.Position == 5)
                {
                    coords.X = 290;
                    coords.Y = 338;
                }
            }
            if (Location.Area == FieldArea.SquareX)
            {
                // Left Box (green)
                if (Location.Position == 0)
                {
                    coords.X = 32;
                    coords.Y = 295;
                }
                if (Location.Position == 1)
                {
                    coords.X = 75;
                    coords.Y = 295;
                }
                if (Location.Position == 2)
                {
                    coords.X = 118;
                    coords.Y = 295;
                }
                if (Location.Position == 3)
                {
                    coords.X = 161;
                    coords.Y = 295;
                }
                if (Location.Position == 4)
                {
                    coords.X = 204;
                    coords.Y = 295;
                }
                if (Location.Position == 5)
                {
                    coords.X = 247;
                    coords.Y = 295;
                }
                if (Location.Position == 51)
                {
                    coords.X = 32;
                    coords.Y = 340;
                }
                if (Location.Position == 50)
                {
                    coords.X = 32;
                    coords.Y = 383;
                }
                if (Location.Position == 49)
                {
                    coords.X = 75;
                    coords.Y = 383;
                }
                if (Location.Position == 48)
                {
                    coords.X = 118;
                    coords.Y = 383;
                }
                if (Location.Position == 47)
                {
                    coords.X = 161;
                    coords.Y = 383;
                }
                if (Location.Position == 46)
                {
                    coords.X = 204;
                    coords.Y = 383;
                }
                if (Location.Position == 45)
                {
                    coords.X = 247;
                    coords.Y = 383;
                }
                // Top Box (yellow)
                if (Location.Position == 10)
                {
                    coords.X = 295;
                    coords.Y = 72;
                }
                if (Location.Position == 9)
                {
                    coords.X = 295;
                    coords.Y = 115;
                }
                if (Location.Position == 8)
                {
                    coords.X = 295;
                    coords.Y = 158;
                }
                if (Location.Position == 7)
                {
                    coords.X = 295;
                    coords.Y = 201;
                }
                if (Location.Position == 6)
                {
                    coords.X = 295;
                    coords.Y = 244;
                }
                if (Location.Position == 11)
                {
                    coords.X = 295;
                    coords.Y = 29;
                }
                if (Location.Position == 12)
                {
                    coords.X = 338;
                    coords.Y = 29;
                }
                if (Location.Position == 13)
                {
                    coords.X = 381;
                    coords.Y = 29;
                }
                if (Location.Position == 14)
                {
                    coords.X = 381;
                    coords.Y = 72;
                }
                if (Location.Position == 15)
                {
                    coords.X = 381;
                    coords.Y = 115;
                }
                if (Location.Position == 16)
                {
                    coords.X = 381;
                    coords.Y = 158;
                }
                if (Location.Position == 17)
                {
                    coords.X = 381;
                    coords.Y = 201;
                }
                if (Location.Position == 18)
                {
                    coords.X = 381;
                    coords.Y = 244;
                }
                // Right box (blue)
                if (Location.Position == 26)
                {
                    coords.X = 635;
                    coords.Y = 383;
                }
                if (Location.Position == 25)
                {
                    coords.X = 635;
                    coords.Y = 338;
                }
                if (Location.Position == 24)
                {
                    coords.X = 635;
                    coords.Y = 295;
                }
                if (Location.Position == 23)
                {
                    coords.X = 592;
                    coords.Y = 295;
                }
                if (Location.Position == 22)
                {
                    coords.X = 549;
                    coords.Y = 295;
                }
                if (Location.Position == 21)
                {
                    coords.X = 506;
                    coords.Y = 295;
                }
                if (Location.Position == 20)
                {
                    coords.X = 463;
                    coords.Y = 295;
                }
                if (Location.Position == 19)
                {
                    coords.X = 420;
                    coords.Y = 295;
                }
                if (Location.Position == 27)
                {
                    coords.X = 592;
                    coords.Y = 383;
                }
                if (Location.Position == 28)
                {
                    coords.X = 549;
                    coords.Y = 383;
                }
                if (Location.Position == 29)
                {
                    coords.X = 506;
                    coords.Y = 383;
                }
                if (Location.Position == 30)
                {
                    coords.X = 463;
                    coords.Y = 383;
                }
                if (Location.Position == 31)
                {
                    coords.X = 420;
                    coords.Y = 383;
                }
                // Red box (red)
                if (Location.Position == 40)
                {
                    coords.X = 295;
                    coords.Y = 605;
                }
                if (Location.Position == 41)
                {
                    coords.X = 295;
                    coords.Y = 562;
                }
                if (Location.Position == 42)
                {
                    coords.X = 295;
                    coords.Y = 519;
                }
                if (Location.Position == 43)
                {
                    coords.X = 295;
                    coords.Y = 471;
                }
                if (Location.Position == 44)
                {
                    coords.X = 295;
                    coords.Y = 428;
                }
                if (Location.Position == 39)
                {
                    coords.X = 295;
                    coords.Y = 648;
                }
                if (Location.Position == 38)
                {
                    coords.X = 338;
                    coords.Y = 648;
                }
                if (Location.Position == 37)
                {
                    coords.X = 383;
                    coords.Y = 648;
                }
                if (Location.Position == 36)
                {
                    coords.X = 383;
                    coords.Y = 605;
                }
                if (Location.Position == 35)
                {
                    coords.X = 383;
                    coords.Y = 562;
                }
                if (Location.Position == 34)
                {
                    coords.X = 383;
                    coords.Y = 519;
                }
                if (Location.Position == 33)
                {
                    coords.X = 383;
                    coords.Y = 471;
                }
                if (Location.Position == 32)
                {
                    coords.X = 383;
                    coords.Y = 428;
                }
            }

            return coords;
        }

        /// <summary>
        /// Shows the current position of the piece on the screen
        /// </summary>
        /// <param name="canvas"></param>
        public void Show(Canvas canvas)
        {
            Point p = GridCoords();

            Canvas.SetTop(i, p.Y);
            Canvas.SetLeft(i, p.X);
            i.UpdateLayout();
        }
    }
}
