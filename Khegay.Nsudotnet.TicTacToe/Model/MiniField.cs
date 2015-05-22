using Khegay.Nsudotnet.TicTacToe.Views;

namespace Khegay.Nsudotnet.TicTacToe.Model
{
    public class MiniField : AbstractField<Mark>
    {
        public bool Active { get; set; }


        public MiniField() : base((a,b) => a == b, a => a, a => a == Mark.No)
        {
        }

        
    }
}
