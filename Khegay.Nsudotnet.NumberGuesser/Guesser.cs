using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Khegay.Nsudotnet.NumberGuesser
{
    class Guesser
    {
        private readonly Taunter _taunter;
        private int _number;
        private List<int> _history = new List<int>(8);
        private int _count;
        public bool Victory { get; private set; }


        public Guesser(Taunter taunter)
        {
            _taunter = taunter;
            Reset();
        }

        public Guesser(string name)
            : this(new Taunter(name)){}

        public void Reset()
        {
            _taunter.Reset();
            _number = new Random().Next(100)+1;
            Victory = false;
            _history.Clear();
        }

        public string Guess(int guess)
        {
            _history.Add(guess);
            ++_count;
            if (guess == _number)
            {
                Victory = true;
                return "Correct!";
            }
            else
            {
                if (_count%4 == 0)
                    return string.Format("My number is {0}.\n{1}", guess < _number ? "bigger" :"smaller", _taunter.Next());
                else
                {
                    return string.Format("My number is {0}", guess < _number ? "bigger" : "smaller");
                }
            }
        }

        public string FormatHistory()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("You tried {0} times\n", _count);
            foreach (var guess in _history)
            {
                builder.AppendFormat("{0} was {1}\n", guess,
                    guess == _number ? "correct" : guess > _number ? "bigger" : "smaller");
            }
            return builder.ToString();
        }
    }
}
