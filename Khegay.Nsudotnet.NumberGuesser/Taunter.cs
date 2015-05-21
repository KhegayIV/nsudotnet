using System;
using System.Collections.Generic;
using System.Linq;

namespace Khegay.Nsudotnet.NumberGuesser
{
    class Taunter
    {

        private uint _level;
        private Dictionary<uint, List<string>> _taunts = new Dictionary<uint, List<string>>();
        private Random _rnd = new Random();
        private readonly string _name;
        
        public Taunter(string name)
        {
            _name = name;
            AddDefaults();
        }

        private void AddDefaults()
        {
            AddTaunt(0,
                "Better luck next time, {0}",
                "So, {0}, you're not very lucky",
                "{0}! Loser! Just kiddin'",
                "Maybe, you should try doing something else, {0}?"
            );
            AddTaunt(2, "You're not very bright, are you, {0}?",
                "{0}, probably, you should think. Sometimes it helps",
                "There is an algorithm. If you know, what this word means, {0}",
                "Lucky guesses rarely help",
                "Oh, {0}, you must be an oracle! By the way, do you know, what the word 'sarcasm' means?",
                "{0}, you win! Oh, just kiddin', loser",
                "Do words 'logarithm' or 'binary searh' mean anything to you, {0}?");
            AddTaunt(5, "Well, {0}, it seems, you're unlucky, dumb and insistent at the same time",
                "Well, well, trying brute force, {0}? Good luck. You'll need either that or some time",
                "Maybe, thinking is not your thing, {0}. You should try something else");
            AddTaunt(24, "You're really THAT unlucky?");
            AddTaunt(25, "Number from 1 to 100. You tried 100 times. And still, you failed! You're the reason, why I am ashamed of humanity");
        }

        public void AddTaunt(uint level = 0, params string[] taunts)
        {
            if (!_taunts.ContainsKey(level))
            {
                _taunts[level] = new List<string>();
            }
            foreach (var taunt in taunts)
            {
                _taunts[level].Add(taunt);
            }
        }

        public void Reset()
        {
            _level = 0;
        }

        public string Next()
        {
            uint level = _taunts.Max(i => i.Key > _level ? 0 : i.Key);
            var list = _taunts[level];
            return String.Format(list[_rnd.Next(list.Count)], _name);
        }
    }
}
