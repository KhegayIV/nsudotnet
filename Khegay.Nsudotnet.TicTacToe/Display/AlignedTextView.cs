using System;
using System.Collections.Generic;
using System.Linq;

namespace Khegay.Nsudotnet.TicTacToe.Display
{
    class AlignedTextView : View
    {
        public Align TextAlign { get; set; }
        public ConsoleColor Color { get; set; }
        private List<string> _text;
        public List<string> Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Height = _text.Count;
            }
        }

        public AlignedTextView(int width, Align align = Align.Left, List<string> text = null, ConsoleColor color = ConsoleColor.White)
            : base(width, 0)
        {
            TextAlign = align;
            Color = color;
            _text = text ?? new List<string>();
        }

        public AlignedTextView(int width, Align align, string text, ConsoleColor color = ConsoleColor.White)
            : this(width, align, text.Split(Environment.NewLine.ToCharArray()).ToList(), color)
        {
            
        }

        protected override Tuple<char, ConsoleColor> Get(int x, int y)
        {
            string s = _text[y];
            switch (TextAlign)
            {
                case Align.Left:
                    return Tuple.Create(s.Length < x ? s[x] : ' ', Color);
                case Align.Right:
                    
                    return Tuple.Create(s.Length >= Width - x  ? s[x - (Width - s.Length)] : ' ', Color);
                //case Align.Center:
                default:
                    int position = x - (Width - s.Length)/2;
                    return Tuple.Create(
                        position >= 0 && position<s.Length ? s[position] : ' ', Color
                        );
            }
        }

        public enum Align{Left, Right, Center}
    }
}
