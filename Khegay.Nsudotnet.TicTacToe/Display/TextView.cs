using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Khegay.Nsudotnet.TicTacToe.Display
{
    public abstract class TextView : View
    {
        
        public ConsoleColor Color { get; set; }

        protected virtual string[] Lines { get; set; }

        public virtual string Text
        {
            set { Lines = value.Replace("\r", "").Split('\n'); }
        }

        public TextView SetLines(params string[] lines)
        {
            this.Lines = lines;
            return this;
        }


        protected TextView(int width = 0, int height = 0, ConsoleColor color = ConsoleColor.White) : base(width, height)
        {
            Color = color;
        }


        protected override Tuple<char, ConsoleColor> Get(int x, int y)
        {
            return Tuple.Create(GetSymbol(x, y), Color);
        }

        protected abstract char GetSymbol(int x, int y);
    }
}
