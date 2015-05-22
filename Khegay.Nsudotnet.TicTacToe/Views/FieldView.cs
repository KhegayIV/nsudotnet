using System;

using Khegay.Nsudotnet.TicTacToe.Display;
using Khegay.Nsudotnet.TicTacToe.Model;

namespace Khegay.Nsudotnet.TicTacToe.Views
{
    public class FieldView : View
    {
        private readonly Field _field;

        //19x19 - 5*3 - minifields, + 4 - edges
        public FieldView(Field field) : base(19, 19)
        {
            _field = field;
        }

        protected override Tuple<char, ConsoleColor> Get(int x, int y)
        {
            //Vertical edge
            if (x%6 == 0)
            {
                return Tuple.Create(y%2 == 0 ? '+' : '|', ConsoleColor.White);
            }
            //Horizontal edge
            if (y % 6 == 0)
            {
                return Tuple.Create(x % 2 == 0 ? '+' : '|', ConsoleColor.White);
            }
            //If not edge, than it's minifield at position x/6, y/6
            return GetFromMinifield(x%6 - 1, y%6 - 1, _field[x/6, y/6]);
        }

        //x, y in limits 0..4 inclusive
        private Tuple<char, ConsoleColor> GetFromMinifield(int x, int y, MiniField field)
        {
            
            ConsoleColor color;
            //Edge color
            if (field.Active)
            {
                switch (field.Victory)
                {
                    case Mark.X:
                        color = Program.XColor;
                        break;
                    case Mark.O:
                        color = Program.OColor;
                        break;
                    default:
                        color = ConsoleColor.White;
                        break;
                }
            }
            else
            {
                switch (field.Victory)
                {
                    case Mark.X:
                        color = Program.XColorPassive;
                        break;
                    case Mark.O:
                        color = Program.OColorPassive;
                        break;
                    default:
                        color = ConsoleColor.Gray;
                        break;
                }
            }
            if (x%2 > 0 && y%2 > 0) return Tuple.Create('+', color);
            if (x%2 > 0) return Tuple.Create('|', color);
            if (y%2 > 0) return Tuple.Create('-', color);
            var mark = field[x/2, y/2];
            if (mark == Mark.No) return Tuple.Create(' ', ConsoleColor.Black);
            //Mark color
            if (field.Draw)
            {
                color = ConsoleColor.DarkGray;
            }
            else
            {
                if (mark == Mark.X)
                {
                    if (field.Victory == Mark.O)
                    {
                        color = Program.XColorPassive;
                    }
                    else
                    {
                        color = Program.XColor;
                    }
                }
                else
                {
                    if (field.Victory == Mark.X)
                    {
                        color = Program.OColorPassive;
                    }
                    else
                    {
                        color = Program.OColor;
                    }
                }
            }
            return Tuple.Create(mark == Mark.X ? 'X' : 'O', color);
        }
    }
}