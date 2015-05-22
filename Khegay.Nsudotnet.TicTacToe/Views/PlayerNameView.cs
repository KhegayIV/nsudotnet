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
            set {
                Color = value ? _colorActive : _colorPassive;
            }
        }

        public PlayerNameView(int width, Align align, ConsoleColor colorActive, ConsoleColor colorPassive)
            : base(width, align)
        {
            _colorActive = colorActive;
            _colorPassive = colorPassive;
        }

        public PlayerNameView SetName(string name)
        {
            SetLines(name);
            return this;
        }



    }
}
