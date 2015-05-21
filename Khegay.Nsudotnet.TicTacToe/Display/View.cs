using System;
using System.Collections;

namespace Khegay.Nsudotnet.TicTacToe.Display
{
    public abstract class View
    {
        public int Width { get; protected set; }
        public int Height { get; protected set; }

        public Tuple<char, ConsoleColor> this[int x, int y]
        {
            get
            {
                if (x < 0 || y < 0 || x >= Width || y >= Height)
                    return new Tuple<char, ConsoleColor>(' ', ConsoleColor.Black);
                return Get(x, y);
            }
        }

        protected View(int width, int height)
        {
            Width = width;
            Height = height;
            
        }

        protected abstract Tuple<char, ConsoleColor> Get(int x, int y);

    }
}
