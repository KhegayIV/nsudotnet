using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Khegay.Nsudotnet.TicTacToe.Display
{
    internal class MultilineTextView : AlignedTextView
    {
        protected override string[] Lines
        {
            get { return base.Lines; }
            set { base.Lines = Recount(value); }
        }

        public MultilineTextView(int width, Align align = Align.Left, ConsoleColor color = ConsoleColor.White)
            : base(width, align, color)
        {
        }

        private string[] Recount(string[] lines)
        {
            var text = new List<string>();
            var stringBuilder = new StringBuilder();
            foreach (var line in lines)
            {
                foreach (var word in line.Split(' '))
                {
                    if (stringBuilder.Length == 0)
                    {
                        if (word.Length > Width)
                        {
                            var s = word;
                            while (s.Length > Width)
                            {
                                text.Add(s.Substring(0, Width));
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
                        text.Add(stringBuilder.ToString());
                        stringBuilder.Clear().Append(word);
                    }
                    else
                    {
                        stringBuilder.Append(' ').Append(word);
                    }

                }
                text.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }
            return text.ToArray();
        }
    }
}
