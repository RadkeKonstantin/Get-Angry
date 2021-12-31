using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Angry
{
    enum Color
    {
        yellow,
        green,
        red,
        black
    }

    class GamePiece
    {
        private const int START_YELLOW = 0;
        private const int START_GREEN = 10;
        private const int START_RED = 20;
        private const int START_BLACK = 30;

        private Color _color;
        private int _position;
        private bool _inHouse;
        private bool _inStart;

        public bool Final;

        public GamePiece(Color color)
        {
            _color = color;
            _inStart = true;
            _inHouse = false;
            Final = false;
            _position = -1;
        }

        public Color Color
        {
            get => _color;
        }

        public int Position
        {
            get => _position;
        }

        public bool InHouse
        {
            get => _inHouse;
        }

        public bool InStart
        {
            get => _inStart;
        }

        public void setStart()
        {
            switch(_color)
            {
                case Color.yellow:
                    _position = START_YELLOW;
                    break;

                case Color.green:
                    _position = START_GREEN;
                    break;

                case Color.red:
                    _position = START_RED;
                    break;

                case Color.black:
                    _position = START_BLACK;
                    break;

                default:
                    return;
            }

            _inStart = false;
        }

        public void reset()
        {
            _position = -1;
            _inStart = true;
            _inHouse = false;
            Final = false;
        }

        /// <summary>
        /// Moves a game piece
        /// </summary>
        /// <param name="distance"></param>
        /// <returns>True on success, false on invalid move</returns>
        public int move(int distance)
        {
            //Check if game piece completed a lap
            int lastField;
            switch(_color)
            {
                case Color.yellow:
                    lastField = START_YELLOW - 1;
                    break;

                case Color.green:
                    lastField = START_GREEN - 1;
                    break;

                case Color.red:
                    lastField = START_RED - 1;
                    break;

                case Color.black:
                    lastField = START_BLACK - 1;
                    break;

                default:
                    return -1;
            }
            if (lastField < 0) lastField += 40;
            if (_position <= lastField && (_position + distance) > lastField)
            {
                _position = _position + distance - lastField;
                _inHouse = true;
                return _position;
            }

            //Make a normal move
            _position += distance;

            //There are only 40 fields per lap, any index higher than 39 needs to be modified
            if (_position > 39) _position -= 40;
            return _position;
        }
    }

    static class GamePieceFactory
    {
        public static List<GamePiece> makeGamePieces()
        {
            List<GamePiece> gamePieces = new List<GamePiece>();
            foreach(Color color in (Color[]) Enum.GetValues(typeof(Color)))
            {
                for (int i = 0; i < 4; i++)
                {
                    gamePieces.Add(new GamePiece(color));
                }
            }

            return gamePieces;
        }
    }
}
