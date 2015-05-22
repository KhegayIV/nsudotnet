using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Khegay.Nsudotnet.TicTacToe.Display;

namespace Khegay.Nsudotnet.TicTacToe.Views
{
    class PlayerNameView : AlignedTextView
    {
        private readonly ConsoleColor _colorActive;
        private readonly ConsoleColor _colorPassive;
        public bool Active
        {
            set
            {
                if (value)
                {
                    Color = _colorActive;
                }
                else
                {
                    Color = _colorPassive;
                }
            }
        }

        public PlayerNameView(int width, Align align, string name, ConsoleColor colorActive, ConsoleColor colorPassive)
            : base(width, align, name)
        {
            _colorActive = colorActive;
            _colorPassive = colorPassive;
        }



    }
}
