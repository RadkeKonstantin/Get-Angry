using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Get_Angry
{
    public partial class Board : Form
    {
        private List<Field> fields = new List<Field>()
        {
            // Start yellow
            FieldFactory.fromFactor(1, 5),
            FieldFactory.fromFactor(2, 5),
            FieldFactory.fromFactor(3, 5),
            FieldFactory.fromFactor(4, 5),
            FieldFactory.fromFactor(5, 5),
            FieldFactory.fromFactor(5, 4),
            FieldFactory.fromFactor(5, 3),
            FieldFactory.fromFactor(5, 2),
            FieldFactory.fromFactor(5, 1),
            FieldFactory.fromFactor(6, 1),
            // Start green
            FieldFactory.fromFactor(7, 1),
            FieldFactory.fromFactor(7, 2),
            FieldFactory.fromFactor(7, 3),
            FieldFactory.fromFactor(7, 4),
            FieldFactory.fromFactor(7, 5),
            FieldFactory.fromFactor(8, 5),
            FieldFactory.fromFactor(9, 5),
            FieldFactory.fromFactor(10, 5),
            FieldFactory.fromFactor(11, 5),
            FieldFactory.fromFactor(11, 6),
            // Start red
            FieldFactory.fromFactor(11, 7),
            FieldFactory.fromFactor(10, 7),
            FieldFactory.fromFactor(9, 7),
            FieldFactory.fromFactor(8, 7),
            FieldFactory.fromFactor(7, 7),
            FieldFactory.fromFactor(7, 8),
            FieldFactory.fromFactor(7, 9),
            FieldFactory.fromFactor(7, 10),
            FieldFactory.fromFactor(7, 11),
            FieldFactory.fromFactor(6, 11),
            // Start black
            FieldFactory.fromFactor(5, 11),
            FieldFactory.fromFactor(5, 10),
            FieldFactory.fromFactor(5, 9),
            FieldFactory.fromFactor(5, 8),
            FieldFactory.fromFactor(5, 7),
            FieldFactory.fromFactor(4, 7),
            FieldFactory.fromFactor(3, 7),
            FieldFactory.fromFactor(2, 7),
            FieldFactory.fromFactor(1, 7),
            FieldFactory.fromFactor(1, 6)
        };

        private List<GamePiece> gamePieces = GamePieceFactory.makeGamePieces();
        private List<Color> winners = new List<Color>();

        public Board()
        {
            InitializeComponent();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        #region Private methods
        private void makeMove(Color color)
        {
            //No move if color already finished playing
            if (winners.Contains(color))
            {
                return;
            }

            //Collect all game pieces of player color
            List<GamePiece> currentPieces = new List<GamePiece>();
            foreach(GamePiece piece in gamePieces)
            {
                if (piece.Color == color)
                {
                    currentPieces.Add(piece);
                }
            }
            
            if (threeThrowsAllowed(color))
            {
                //Three tries allowed to get a '6'
                int result = 0;
                int tries = 0;
                while(result != 6 && tries <= 3)
                {
                    result = Dice.throwDice();
                    tries++;
                }
                if (result == 6)
                {
                    foreach(GamePiece piece in currentPieces)
                    {
                        if(piece.InStart)
                        {
                            piece.setStart();
                        }
                    }
                }
                else
                {
                    return;
                }
            }

            //Make an actual move
            int diceResult = Dice.throwDice();
            //1) Check if start field needs to be freed

            //2) Check if a brutal murder is possible

            //3) Maybe move up in house?

            //4) Nah, just take the most advanced game piece


            //Check if player has finished
            if (allFinal(color))
            {
                winners.Add(color);
            }
        }

        private bool oneInStart(Color color)
        {
            return false;
        }

        private bool allFinal(Color color)
        {
            bool finished = true;
            foreach (GamePiece piece in gamePieces)
            {
                if (piece.Color != color) continue;
                finished = finished && piece.Final;
            }
            return finished;
        }

        private bool threeThrowsAllowed(Color color)
        {
            bool tripleThrow = true;
            foreach (GamePiece piece in gamePieces)
            {
                if (piece.Color != color) continue;
                tripleThrow = piece.InStart || piece.Final;
            }
            return tripleThrow;
        }
        #endregion
    }

    /// <summary>
    /// Resembles a field on the game board, used in class <see cref="Board"/>
    /// </summary>
    public class Field
    {
        public int x;
        public int y;

        /// <summary>
        /// Creates a new field based on x and y pixel coordinate
        /// </summary>
        /// <param name="coord_x">x coordinate</param>
        /// <param name="coord_y">y coordinate</param>
        public Field(int coord_x, int coord_y)
        {
            x = coord_x;
            y = coord_y;
        }
    }

    /// <summary>
    /// Creates a <see cref="Field"/> with a constant offset
    /// </summary>
    public static class FieldFactory
    {
        private const int OFFSET = 64;

        public static Field fromFactor(int factor_x, int factor_y)
        {
            return new Field(factor_x * OFFSET, factor_y * OFFSET);
        }
    }
}
