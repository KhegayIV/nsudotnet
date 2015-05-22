using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Khegay.Nsudotnet.TicTacToe.Display
{
    public class StaticTextView: TextView
    {
        //LSP?
        protected override string[] Lines
        {
            get { return base.Lines; }
            set
            {
                base.Lines = value;
                Height = Lines.Length;
                Width = Lines.Max(s => s.Length);
            } 
        }

        public StaticTextView(ConsoleColor color = ConsoleColor.White) : base(0,0, color)
        {
        }

        protected override char GetSymbol(int x, int y)
        {
            var s = Lines[y];
            return s.Length > x ? s[x] : ' ';
        }
    }
}
