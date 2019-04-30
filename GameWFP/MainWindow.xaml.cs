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
                new Player(PlayerColor.green),
                new Player(PlayerColor.yellow),
                new Player(PlayerColor.blue),
                new Player(PlayerColor.red)
            };

            TurnInfo.Text = $"It's {_activePlayer.ToString()}'s turn";
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
            // Get the position of the mouse
            var mp = Mouse.GetPosition(Application.Current.MainWindow);

            // Find the location that corresponds to the position of the mouse
            FieldLocation Location = new FieldLocation(mp);

            // TODO: Some temporary code that helps debugging
            _statusMessage = $"Mouse.x: {mp.X}, mouse.y: {mp.Y}";

            _statusMessage += $"{Environment.NewLine}{Location.Area.ToString()}: {Location.Position}";
            StatusBox.Text = _statusMessage;
        }

        #endregion
    }

    /// <summary>
    /// All possible player colors
    /// </summary>
    public enum PlayerColor
    {
        green,
        yellow,
        blue,
        red,
        none
    }

    /// <summary>
    /// Possible phases the game can be in
    /// </summary>
    public enum Phase
    {
        RollDie,
        ChooseMove,
        GameOver
    }

    /// <summary>
    /// Stores information for each pawn
    /// </summary>
    public class Pawn
    {
        PlayerColor Color { get; }

        FieldLocation Location { get; set; }

        public Pawn(PlayerColor color, int position)
        {
            Color = color;
            if (color == PlayerColor.green)
                Location = new FieldLocation(FieldArea.GreenHome, position);
            else if (color == PlayerColor.yellow)
                Location = new FieldLocation(FieldArea.YellowHome, position);
            else if (color == PlayerColor.blue)
                Location = new FieldLocation(FieldArea.BlueHome, position);
            else if (color == PlayerColor.red)
                Location = new FieldLocation(FieldArea.RedHome, position);
            else
                throw new Exception("Invalid color for pawn.");
        }
    }

    public class Player
    {
        PlayerColor Color { get; set; }
        Pawn[] _pawns;

        public Player(PlayerColor color)
        {
            _pawns = new Pawn[4];

            for (int i = 0; i < _pawns.Length; i++)
            {
                _pawns[i] = new Pawn(color, i);
            }
        }
    }
}
