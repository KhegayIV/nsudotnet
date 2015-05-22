using System;
using System.Collections.Generic;
using System.Linq;

namespace Khegay.Nsudotnet.TicTacToe.Display
{
    class AlignedTextView : TextView
    {
        public Align TextAlign { get; set; }

        protected override string[] Lines
        {
            get { return base.Lines; }
            set
            {
                base.Lines = value;
                Height = value.Length;
            }
        }

        protected override char GetSymbol(int x, int y)
        {
            string s = Lines[y];
            switch (TextAlign)
            {
                case Align.Left:
                    return s.Length > x ? s[x] : ' ';
                case Align.Right:

                    return s.Length >= Width - x ? s[x - (Width - s.Length)] : ' ';
                //case Align.Center:
                default:
                    int position = x - (Width - s.Length) / 2;
                    return position >= 0 && position < s.Length ? s[position] : ' ';
            }
        }

        public AlignedTextView(int width, Align align = Align.Left, ConsoleColor color = ConsoleColor.White) : base(width, 0, color)
        {
            TextAlign = align;
        }

        public enum Align { Left, Right, Center }
    }

         
}
