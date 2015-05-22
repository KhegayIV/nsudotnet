using System;
using System.Linq;

namespace Khegay.Nsudotnet.TicTacToe.Model
{
    //Base class for both field and minifield
    public abstract class AbstractField<TCell> where TCell: new()
    {
        

        private readonly TCell[,] _cells;

        
        //Func, which checks if two cells are equal
        private readonly Func<TCell, TCell, bool> _cellEqual;
        //Func, which returns Victory of TVictory, based on winning cell
        private readonly Func<TCell, Mark> _cellVictoryMark;
        //Checks if 3-of-a-kind counts
        private readonly Func<TCell, bool> _cellIsMutable; 

        protected AbstractField(Func<TCell, TCell, bool> cellEqual, Func<TCell, Mark> cellVictoryMark, Func<TCell, bool> cellIsMutable)
        {
            _cellEqual = cellEqual;
            _cellVictoryMark = cellVictoryMark;
            _cellIsMutable = cellIsMutable;

            _cells = new TCell[3, 3];
            for (int i = 0; i < 9; i++)
            {
                _cells[i % 3, i / 3] = new TCell();
            }
        }

        public virtual void Reset()
        {
            for (int i = 0; i < 9; i++)
            {
                _cells[i % 3, i / 3] = new TCell();
            }
            Victory = Mark.No;
            Draw = false;
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

        public Mark Victory { get; protected set ; }
        public bool Draw { get; protected set; }


        public void Check()
        {
            if (Draw || Victory != Mark.No) return;
            for (int i = 0; i < 3; i++)
            {
                //Check vertical
                if (!_cellIsMutable(this[i,1]) 
                    && _cellEqual.Invoke(this[i, 1], this[i, 0]) 
                    && _cellEqual.Invoke(this[i, 1], this[i, 2]))
                {
                    Victory = _cellVictoryMark.Invoke(this[i,1]);
                    return;
                }
                //Check horizontal
                if (!_cellIsMutable(this[1, i]) 
                    && _cellEqual.Invoke(this[1, i], this[0, i]) 
                    && _cellEqual.Invoke(this[1, i], this[2, i]))
                {
                    Victory = _cellVictoryMark.Invoke(this[1, i]);
                    return;
                }

            }
            //Check diagonal
            if (!_cellIsMutable(this[1, 1]) && (
                _cellEqual.Invoke(this[0, 0], this[1, 1]) && _cellEqual.Invoke(this[2, 2], this[1, 1]) ||
                _cellEqual.Invoke(this[0, 2], this[1, 1]) && _cellEqual.Invoke(this[2, 0], this[1, 1])))
            {
                Victory = _cellVictoryMark.Invoke(this[1, 1]);
                return;
            }
            if (EmptyCells() == 0)
            {
                Draw = true;
            }
        }

        public int EmptyCells()
        {
            return _cells.Cast<TCell>().Count(e => _cellIsMutable(e));
        }
        
    }
}