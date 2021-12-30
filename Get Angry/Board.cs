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
        public List<Field> fields = new List<Field>()
        {
            // Start yellow
            FieldFactory.from_factor(1, 5),
            FieldFactory.from_factor(2, 5),
            FieldFactory.from_factor(3, 5),
            FieldFactory.from_factor(4, 5),
            FieldFactory.from_factor(5, 5),
            FieldFactory.from_factor(5, 4),
            FieldFactory.from_factor(5, 3),
            FieldFactory.from_factor(5, 2),
            FieldFactory.from_factor(5, 1),
            FieldFactory.from_factor(6, 1),
            // Start green
            FieldFactory.from_factor(7, 1),
            FieldFactory.from_factor(7, 2),
            FieldFactory.from_factor(7, 3),
            FieldFactory.from_factor(7, 4),
            FieldFactory.from_factor(7, 5),
            FieldFactory.from_factor(8, 5),
            FieldFactory.from_factor(9, 5),
            FieldFactory.from_factor(10, 5),
            FieldFactory.from_factor(11, 5),
            FieldFactory.from_factor(11, 6),
            // Start red
            FieldFactory.from_factor(11, 7),
            FieldFactory.from_factor(10, 7),
            FieldFactory.from_factor(9, 7),
            FieldFactory.from_factor(8, 7),
            FieldFactory.from_factor(7, 7),
            FieldFactory.from_factor(7, 8),
            FieldFactory.from_factor(7, 9),
            FieldFactory.from_factor(7, 10),
            FieldFactory.from_factor(7, 11),
            FieldFactory.from_factor(6, 11),
            // Start black
            FieldFactory.from_factor(5, 11),
            FieldFactory.from_factor(5, 10),
            FieldFactory.from_factor(5, 9),
            FieldFactory.from_factor(5, 8),
            FieldFactory.from_factor(5, 7),
            FieldFactory.from_factor(4, 7),
            FieldFactory.from_factor(3, 7),
            FieldFactory.from_factor(2, 7),
            FieldFactory.from_factor(1, 7),
            FieldFactory.from_factor(1, 6)
        };

        public Board()
        {
            InitializeComponent();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }

    /// <summary>
    /// Resembles a field on the game board, used in class <see cref="Board"/>
    /// </summary>
    public class Field
    {
        private const int OFFSET = 64;

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

    public static class FieldFactory
    {
        private const int OFFSET = 64;

        public static Field from_factor(int factor_x, int factor_y)
        {
            return new Field(factor_x * OFFSET, factor_y * OFFSET);
        }
    }
}
