using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Khegay.Nsudotnet.TicTacToe.Views;

namespace Khegay.Nsudotnet.TicTacToe
{
    class MiniField : AbstractField<Mark>
    {
        public bool Active { get; set; }


        public MiniField() : base((a,b) => a == b, a => a, a => a == Mark.No)
        {
        }

        
    }
}
