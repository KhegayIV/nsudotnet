using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Khegay.Nsudotnet.TicTacToe.Display;
using Khegay.Nsudotnet.TicTacToe.Model;
using Khegay.Nsudotnet.TicTacToe.Views;

namespace Khegay.Nsudotnet.TicTacToe
{
    class Game
    {
        private ConsoleDisplay _display = new ConsoleDisplay();
        private Field _field = new Field();
        

        public Game()
        {
            _display.Add(5,5, new FieldView(_field));
            
            _display.Add(5,4, new AlignedTextView(9, AlignedTextView.Align.Left, "Player X", Program.XColor));
            _display.Add(5, 4, new AlignedTextView(9, AlignedTextView.Align.Left, "Player X", Program.XColor));
            
        }
    }
}
