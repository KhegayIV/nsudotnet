using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Khegay.Nsudotnet.TicTacToe.Display
{
    public class TextView: View
    {
        public ConsoleColor Color { get; set; }
        private List<string> _text;

        public List<string> Text
        {
            get { return _text; }
            set
            {
                _text = value;
                Height = _text.Count;
                Width = _text.Max(s => s.Length);
            }
        }

        public TextView(List<string> text = null, ConsoleColor color = ConsoleColor.White) : base(0, 0)
        {
            Color = color;
            _text = text ?? new List<string>();
        }

        public TextView(string text, ConsoleColor color = ConsoleColor.White)
            : this(text.Split(Environment.NewLine.ToCharArray()).ToList(), color)
        {
            
        }

        protected override Tuple<char, ConsoleColor> Get(int x, int y)
        {
            var s = _text[y];
            return Tuple.Create(s.Length < x ? s[x] : ' ', Color);
        }
    }
}
