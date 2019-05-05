using System.Linq;
using System.Windows.Controls;

namespace GameWFP
{
    /// <summary>
    /// Class that contains informations about a player and his pawns
    /// </summary>
    public class Player
    {
        public PlayerColor Color { get; set; }
        public Pawn[] _pawns;
        public FieldArea _start;
        public FieldArea _finish;

        static FieldArea[] _starts = { FieldArea.GreenHome, FieldArea.YellowHome, FieldArea.BlueHome, FieldArea.RedHome };
        static FieldArea[] _finishes = { FieldArea.GreenFinish, FieldArea.YellowFinish, FieldArea.BlueFinish, FieldArea.RedFinish };

        /// <summary>
        /// Constructor that sets up the color and pawns for a player and draws each pawn to the screen
        /// </summary>
        /// <param name="color"></param>
        /// <param name="fieldCanvas"></param>
        public Player(PlayerColor color, Canvas fieldCanvas)
        {
            Color = color;
            if (color == PlayerColor.green)
            {
                _start = FieldArea.GreenHome;
                _finish = FieldArea.GreenFinish;
            }
            if (color == PlayerColor.yellow)
            {
                _start = FieldArea.YellowHome;
                _finish = FieldArea.YellowFinish;
            }
            if (color == PlayerColor.blue)
            {
                _start = FieldArea.BlueHome;
                _finish = FieldArea.BlueFinish;
            }
            if (color == PlayerColor.red)
            {
                _start = FieldArea.RedHome;
                _finish = FieldArea.RedFinish;
            }

            _pawns = new Pawn[4];

            for (int i = 0; i < _pawns.Length; i++)
            {
                _pawns[i] = new Pawn(color, i, fieldCanvas);
            }
        }

        /// <summary>
        /// Returns whether a player actually has a piece in the location and whether the player
        /// can move this piece
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public bool HasPieceIn(FieldLocation location)
        {
            // If the player has clicked on a home
            if (location.Area == FieldArea.GreenHome ||
                location.Area == FieldArea.YellowHome ||
                location.Area == FieldArea.BlueHome ||
                location.Area == FieldArea.RedHome)
            {
                // ... then only Area needs to match
                if (_pawns.Any(p => p.Location.Area == location.Area))
                {
                    return true;
                }
            }
            // otherwise, both Area and position will need to match

            if (_pawns.Any(p => p.Location.Area == location.Area && p.Location.Position == location.Position))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Will return whether the player has won
        /// </summary>
        /// <returns></returns>
        public bool HasWon()
        {
            // If any player piece is not in position 6 or a finishing area
            foreach (var item in _pawns)
            {
                if (item.Location.Position != 6 ||
                    !(new FieldArea[4] {
                        FieldArea.GreenFinish,
                        FieldArea.YellowFinish,
                        FieldArea.BlueFinish,
                        FieldArea.RedFinish }).Contains(item.Location.Area))
                    // Player has not won the game
                    return false;
            }
            // Player has won the game
            return true;
        }

        /// <summary>
        /// Will calculate new position after move
        /// </summary>
        /// <param name="location"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public FieldLocation CalculateMove(FieldLocation location, int distance)
        {
            FieldLocation newLocation = new FieldLocation(location);

            // Advance the player through the regular area and move to the appropriate finish area if needed
            if(location.Area == FieldArea.SquareX)
            {
                newLocation.Position = location.Position + distance;

                if(Color == PlayerColor.green && location.Position + distance > 51)
                {
                    newLocation.Position -= 51;
                    newLocation.Area = FieldArea.GreenFinish;
                }
                if(Color == PlayerColor.yellow && newLocation.Position > 12 && location.Position < 13)
                {
                    newLocation.Position -= 12;
                    newLocation.Area = FieldArea.YellowFinish;
                }
                if (Color == PlayerColor.blue && newLocation.Position > 25 && location.Position < 26)
                {
                    newLocation.Position -= 25;
                    newLocation.Area = FieldArea.BlueFinish;
                }
                if (Color == PlayerColor.red && newLocation.Position > 38 && location.Position < 39)
                {
                    newLocation.Position -= 38;
                    newLocation.Area = FieldArea.RedFinish;
                }

                newLocation.Position %= 52; // Only 52 regular positions on the board
            }

            // If player is in home
            else if ((new FieldArea[] {
                FieldArea.GreenHome,
                FieldArea.YellowHome,
                FieldArea.BlueHome,
                FieldArea.RedHome }).Contains(location.Area))
            {
                newLocation.Area = FieldArea.SquareX;
                if (Color == PlayerColor.green)
                {
                    newLocation.Position = distance + 0;
                }
                else if (Color == PlayerColor.yellow)
                {
                    newLocation.Position = distance + 13;
                }
                else if (Color == PlayerColor.blue)
                {
                    newLocation.Position = distance + 26;
                }
                else if (Color == PlayerColor.red)
                {
                    newLocation.Position = distance + 39;
                }
            }
            // Player is in finish area
            else
            {
                newLocation.Position += distance;
                if (newLocation.Position > 6)
                    newLocation.Position = 6 - (newLocation.Position - 6);
            }
            return newLocation;
        }

        /// <summary>
        /// Moves a piece from one location to another if the player has a piece in that location
        /// </summary>
        /// <param name="oldLocation"></param>
        /// <param name="newLocation"></param>
        public void MovePiece(FieldLocation oldLocation, FieldLocation newLocation)
        {
            foreach (var item in _pawns)
            {
                // If there is a piece in home and the old location is in the home
                if((_starts.Contains(oldLocation.Area) && item.Location.Area == oldLocation.Area) ||
                    // otherwise, if piece is in old location
                    (item.Location.Area == oldLocation.Area && item.Location.Position == oldLocation.Position))
                {
                    // update the location
                    item.Location.Area = newLocation.Area;
                    item.Location.Position = newLocation.Position;
                    return;
                }
            }
        }

        /// <summary>
        /// Will display the player's pieces to the screen
        /// </summary>
        /// <param name="canvas"></param>
        public void Show(Canvas canvas)
        {
            foreach (var item in _pawns)
            {
                item.Show(canvas);
            }
        }

        /// <summary>
        /// Removes the piece from the board that is at the specified location and sends it
        /// back to the player's home
        /// </summary>
        /// <param name="location"></param>
        public void RemovePiece(FieldLocation location)
        {
            // Find the piece at the specified location
            foreach (var item in _pawns)
            {
                // If the Area and Position match, the piece is at the specified location
                if (item.Location.Area == location.Area && item.Location.Position == location.Position)
                {
                    // Find a free spot in the player's home
                    for (int i = 0; i < _pawns.Length; i++)
                    {
                        // If there are not any pieces that are in position i and that are not at home
                        // (pieces at the start of the board will not be confused for pieces being in the home)
                        // then spot is available
                        if (!_pawns.Any(p => p.Location.Position == i && p.Location.Area == _start))
                        {
                            // Put the piece back in the player's home
                            item.Location.Area = _start;

                            // Put the piece in the correct position in the player home
                            item.Location.Position = i;
                            return;
                        }
                    }
                }
            }
        }
    }
}
