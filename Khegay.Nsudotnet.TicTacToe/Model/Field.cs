using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Khegay.Nsudotnet.TicTacToe.Views;

namespace Khegay.Nsudotnet.TicTacToe
{
    class Field : AbstractField<MiniField, Mark>
    {
        private MiniField _current;
        private Mark _player = Mark.X;

        public Field() : base((a,b) => a.Victory == b.Victory, a => a.Victory, a => a.Victory == Mark.No)
        {
        }


        public void Step(int x, int y)
        {
            if (_current == null)
            {
                ChooseCurrent(x, y);
            }
            else
            {
                StepCurrent(x, y);
            }
        }

        private void ChooseCurrent(int x, int y)
        {
            if (_current != null)
            {
                _current.Active = false;
            }
            _current = this[x, y];
            _current.Active = true;
        }

        private void StepCurrent(int x, int y)
        {
            _current[x, y] = _player;
            Check();
            ChooseCurrent(x,y);
        }
    }
}
