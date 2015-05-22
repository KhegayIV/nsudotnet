using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Khegay.Nsudotnet.TicTacToe.Display
{
    class MultilineTextView : AlignedTextView
    {
        private string _line;

        public string Line
        {
            get { return _line; }
            set
            {
                _line = value; 
                Recount();
            }
        }


        public MultilineTextView(int width, Align align = Align.Left, string text ="", ConsoleColor color = ConsoleColor.White) : base(width, align)
        {
            Line = text;
        }

        private void Recount()
        {
            Text = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var word in _line.Split(' '))
            {
                if (stringBuilder.Length == 0)
                {
                    if (word.Length > Width)
                    {
                        var s = word;
                        while (s.Length > Width)
                        {
                            Text.Add(s.Substring(0, Width));
                            s = s.Remove(0, Width);
                        }
                        stringBuilder.Append(s);
                        continue;
                    }

                    stringBuilder.Append(word);
                    continue;
                }

                if (stringBuilder.Length + 1 + word.Length > Width)
                {
                    Text.Add(stringBuilder.ToString());
                    stringBuilder.Clear().Append(word);
                }
                else
                {
                    stringBuilder.Append(' ').Append(word);
                }
                
            }
        }
    }
}
