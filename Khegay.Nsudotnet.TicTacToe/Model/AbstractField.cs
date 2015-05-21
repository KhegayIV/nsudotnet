using System;
using System.Collections.Generic;

namespace Khegay.Nsudotnet.TicTacToe.Views
{
    //Base class for both field and minifield
    public abstract class AbstractField<TCell, TVictory>
    {
        
        private readonly TCell[,] _cells;
        //Func, which checks if two cells are equal
        private readonly Func<TCell, TCell, bool> _cellEqual;
        //Func, which returns Victory of TVictory, based on winning cell
        private readonly Func<TCell, TVictory> _victoryOut;
        //Checks if 3-of-a-kind counts
        private readonly Func<TCell, bool> _doesNotCount; 

        protected AbstractField(Func<TCell, TCell, bool> cellEqual, Func<TCell, TVictory> victoryOut, Func<TCell, bool> doesNotCount)
        {
            _cellEqual = cellEqual;
            _victoryOut = victoryOut;
            _doesNotCount = doesNotCount;

            _cells = new TCell[3, 3];
        }

        public TCell this[int x, int y]
        {
            get { return _cells[x, y]; }
            set { _cells[x, y] = value; Check(); }
        }

        public TCell this[int pos]
        {
            get { return this[pos % 3, pos / 3]; }
            set
            {
                this[pos % 3, pos / 3] = value;
                Check();
            }
        }

        public TVictory Victory { get; private set; }

        public void Check()
        {
            if (!EqualityComparer<TVictory>.Default.Equals(Victory, default(TVictory))) return;
            for (int i = 0; i < 3; i++)
            {
                //Check vertical
                if (!_doesNotCount(this[i,1]) && _cellEqual.Invoke(this[i, 1], this[i, 0]) && _cellEqual.Invoke(this[i, 1], this[i, 2]))
                {
                    Victory = _victoryOut.Invoke(this[i,1]);
                    return;
                }
                //Check horizontal
                if (!_doesNotCount(this[1, i]) && _cellEqual.Invoke(this[1, i], this[0, i]) && _cellEqual.Invoke(this[1, i], this[2, i]))
                {
                    Victory = _victoryOut.Invoke(this[1, i]);
                    return;
                }

            }
            //Check diagonal
            if (!_doesNotCount(this[1, 1]) && (
                _cellEqual.Invoke(this[0, 0], this[1, 1]) && _cellEqual.Invoke(this[2, 2], this[1, 1]) ||
                _cellEqual.Invoke(this[0, 2], this[1, 1]) && _cellEqual.Invoke(this[2, 0], this[1, 1])))
            {
                Victory = _victoryOut.Invoke(this[1, 1]);
            }
        }
        
    }
}