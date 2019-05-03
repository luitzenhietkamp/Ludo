using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameWFP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random _rng;
        int Die { get; set; }
        string _statusMessage;
        int _activePlayer;
        Phase _currentPhase;
        Player[] _players;
        static FieldArea[] _starts = { FieldArea.GreenHome, FieldArea.YellowHome, FieldArea.BlueHome, FieldArea.RedHome };
        static FieldArea[] _finishes = { FieldArea.GreenFinish, FieldArea.YellowFinish, FieldArea.BlueFinish, FieldArea.RedFinish };

        public MainWindow()
        {
            // Default initialisation
            InitializeComponent();

            // Custom initialisation
            Initialise();
        }

        /// <summary>
        /// Custom initialisation of the MainWindow class
        /// </summary>
        public void Initialise()
        {
            _rng = new Random();
            _activePlayer = 0;
            _currentPhase = Phase.RollDie;
            _players = new Player[4] {
                new Player(PlayerColor.green, FieldCanvas),
                new Player(PlayerColor.yellow, FieldCanvas),
                new Player(PlayerColor.blue, FieldCanvas),
                new Player(PlayerColor.red, FieldCanvas)
            };

            foreach (var item in _players)
            {
                item.Show(FieldCanvas);
            }

            _statusMessage = $"{ActivePlayerString()}{Environment.NewLine}Please roll the die to continue.";
            StatusBox.Text = _statusMessage;

        }

        #region Click handlers

        /// <summary>
        /// Method that is called when the RollDie button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RollDie_Click(object sender, RoutedEventArgs e)
        {
            // Only roll the die when the player has not rolled the die yet.
            if (_currentPhase == Phase.RollDie)
            {
                Die = _rng.Next(1, 7);
                _statusMessage = $"You rolled a {Die}. Please select the token you want to move.";
                StatusBox.Text = _statusMessage;
                _currentPhase = Phase.ChooseMove;
            }
            // Otherwise give the player an error message and do nothing.
            else if (_currentPhase == Phase.ChooseMove)
            {
                _statusMessage = $"You already rolled the die. Please select your token to move {Die} steps forward.";
                StatusBox.Text = _statusMessage;
            }
        }

        /// <summary>
        /// Method that is called when the player clicks somewhere in the field.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Field_Click(object sender, RoutedEventArgs e)
        {

            // If a player has completed the game, all clicks will be ignored
            if (_currentPhase == Phase.GameOver) return;

            // Only let the player move his piece after rolling the dice.
            if (_currentPhase != Phase.ChooseMove)
            {
                _statusMessage = $"{ActivePlayerString()}{Environment.NewLine}You cannot move a piece, please roll the die.";
                StatusBox.Text = _statusMessage;
                return;
            }

            // If there are no available moves, a player forfeits their turn

            // Get the position of the mouse
            var mp = Mouse.GetPosition(Application.Current.MainWindow);

            // Find the location that corresponds to the position of the mouse
            FieldLocation location = new FieldLocation(mp);

            // If player can make a move, move
            if(_players[_activePlayer].HasPieceIn(location) && AttemptMove(_players[_activePlayer], location))
            {
                // First check if the game is over
                if (_players[_activePlayer].HasWon())
                {
                    _currentPhase = Phase.GameOver;
                    _statusMessage = $"Congratulations, you have won the game. The {_players[_activePlayer]} player is the winner.";
                    StatusBox.Text = _statusMessage;
                }
                else    // update the game
                {
                    // Update the screen
                    foreach (var item in _players)
                    {
                        item.Show(FieldCanvas);
                    }

                    FieldCanvas.Dispatcher.Invoke(delegate { }, DispatcherPriority.Render);

                    _currentPhase = Phase.RollDie;
                    ++_activePlayer;    // move to the next player
                    _activePlayer %= 4; // move back to the first player, if needed
                    _statusMessage = $"{ActivePlayerString()}{Environment.NewLine}Please roll the die to continue.";
                    StatusBox.Text = _statusMessage;
                }
            }
            else
            {
                // Notify user of invalid move
                _statusMessage = $"{ActivePlayerString()}{Environment.NewLine}Invalid move, you cannot move that piece or do not have a piece at that position";
                StatusBox.Text = _statusMessage;
            }
        }

        #endregion

        /// <summary>
        /// Method that will attempt to move a piece and report the caller whether it was succesful
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        private bool AttemptMove(Player player, FieldLocation location)
        {
            // If the clicked location does not contain a player piece, return false
            if (!player.HasPieceIn(location))
                return false;

            // Calculate the new position
            var newLocation = player.CalculateMove(location, Die);

            // Don't move if the player already has a piece in the new location
            if (player.HasPieceIn(newLocation))
                return false;

            // Move the piecee
            player.MovePiece(location, newLocation);

            // Remove opponent piece, if needed
            foreach (var item in _players)
            {
                // Only check opponents
                if (item.Color != player.Color)
                    item.RemovePiece(newLocation);
            }

            return true;
        }
        public string ActivePlayerString()
        {
            string[] player_strings = { "green", "yellow", "blue", "red" };
            return $"It's {player_strings[_activePlayer]}'s turn.";
        }
    }
}
