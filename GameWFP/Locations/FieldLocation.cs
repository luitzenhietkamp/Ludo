using System.Windows;

namespace GameWFP
{
    /// <summary>
    /// Type that stores the location in a field
    /// </summary>
    public class FieldLocation
    {
        public FieldArea Area { get; set; }
        int Position { get; set; }  // TODO: add checks

        public FieldLocation(FieldArea area, int position)
        {
            Area = area;
            Position = position;
        }

        // TODO: Implement checks
        // TODO: Clean up magic numbers
        // TODO: > or >= ?
        public FieldLocation(Point mousePosition)
        {
            // Green start
            if (mousePosition.X > 169 && mousePosition.X < 427
                && mousePosition.Y > 33 && mousePosition.Y < 291)
            {
                Area = FieldArea.GreenHome;
                Position = -1;
                return;
            }
            // Yellow start
            else if (mousePosition.X > 556 && mousePosition.X < 814
                && mousePosition.Y > 33 && mousePosition.Y < 291)
            {
                Area = FieldArea.YellowHome;
                Position = -1;
            }
            // Blue start
            else if (mousePosition.X > 556 && mousePosition.X < 814
                && mousePosition.Y > 420 && mousePosition.Y < 678)
            {
                Area = FieldArea.BlueHome;
                Position = -1;
            }
            // Red start
            else if (mousePosition.X > 169 && mousePosition.X < 427
                && mousePosition.Y > 420 && mousePosition.Y < 678)
            {
                Area = FieldArea.RedHome;
                Position = -1;
            }
            // Top box
            else if (mousePosition.X > 427 && mousePosition.X < 556
                && mousePosition.Y > 33 && mousePosition.Y < 291)
            {
                Vector offset = new Vector(427, 33);
                mousePosition.X -= offset.X;
                mousePosition.Y -= offset.Y;
            }
            // Player did not click on any active element
            else
            {
                Area = FieldArea.None;
                Position = -1;
            }
        }

        #region Location helpers

        private void SetTop(int square)
        {
            Area = FieldArea.SquareX;

            if (square < 6)
            {
                Position = square + 6;
            }
            else if (square == 11)
            {
                Position = 12;
            }
            else if (square > 5 && square < 11)
            {
                Position = 11 - square;
                Area = FieldArea.YellowFinish;
            }
            else
            {
                Position = 30 - square;
            }
        }

        private void SetRight(int square)
        {
            Area = FieldArea.SquareX;

            if (square < 6)
            {
                Position = square + 19;
            }
            else if (square == 11)
            {
                Position = 25;
            }
            else if (square > 5 && square < 11)
            {
                Position = 11 - square;
                Area = FieldArea.BlueFinish;
            }
            else
            {
                Position = 43 - square;
            }
        }

        private void SetBottom(int square)
        {
            Area = FieldArea.SquareX;

            if (square < 6)
            {
                Position = square + 32;
            }
            else if (square == 11)
            {
                Position = 38;
            }
            else if (square > 5 && square < 11)
            {
                Position = 11 - square;
                Area = FieldArea.RedFinish;
            }
            else
            {
                Position = 56 - square;
            }
        }

        private void SetLeft(int square)
        {
            Area = FieldArea.SquareX;

            if (square < 6)
            {
                Position = square + 45;
            }
            else if (square == 11)
            {
                Position = 51;
            }
            else if (square > 5 && square < 11)
            {
                Position = 11 - square;
                Area = FieldArea.GreenFinish;
            }
            else
            {
                Position = 17 - square;
            }
        }

        #endregion
    }
}