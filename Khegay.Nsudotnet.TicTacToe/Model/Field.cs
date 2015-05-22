using Khegay.Nsudotnet.TicTacToe.Views;

namespace Khegay.Nsudotnet.TicTacToe.Model
{
    public class Field : AbstractField<MiniField>
    {
        private MiniField _current;
        private Mark _player = Mark.X;
        public Mark Player
        {
            get { return _player; }
        }

        public Field() : base((a,b) => a.Victory == b.Victory, a => a.Victory, a => !a.Draw && a.Victory == Mark.No)
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
            _player = _player == Mark.O ? Mark.X : Mark.O;
            ChooseCurrent(x,y);
        }
    }
}
