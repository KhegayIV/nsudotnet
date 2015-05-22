using System;
using System.Collections.Generic;
using System.Linq;

namespace Khegay.Nsudotnet.TicTacToe.Display
{
    public class ConsoleDisplay
    {
        //List of (x0,y0,view) tuples
        private List<Tuple<int, int, View>> _views = new List<Tuple<int, int, View>>();

        public int Width
        {
            get { return _views.Max(e => e.Item1 + e.Item3.Width); }
        }
        public int Height
        {
            get { return _views.Max(e => e.Item2 + e.Item3.Height); }
        }

        public void Add(int x, int y, View view)
        {
            _views.Add(Tuple.Create(x,y,view));
        }

        public void Remove(View view)
        {
            _views.RemoveAll(e => e.Item3 == view);
        }

        public void Draw()
        {
            Console.Clear();
            
            //Dictionary, that stores offset from top-left corner of view and view itself
            var dxdy = new Dictionary<Tuple<int, int>, Tuple<int, int, View>>();

            //Filling dxdy
            foreach (var tuple in _views)
            {
                for (int y = 0; y < tuple.Item3.Height; y++)
                {
                    for (int x = 0; x < tuple.Item3.Width; x++)
                    {
                        dxdy[Tuple.Create(x+tuple.Item1, y+tuple.Item2)] = Tuple.Create(x, y, tuple.Item3);
                    }
                }
                
            }

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    
                    //if (x == 38) Console.Write("!");
                    Tuple<int, int, View> tuple;
                    if (!dxdy.TryGetValue(Tuple.Create(x, y), out tuple))
                    {
                        Console.Write(' ');
                        continue;
                    }
                    //Getting letter and color at dx, dy
                    var letter = tuple.Item3[tuple.Item1, tuple.Item2];
                    //Set text color from letter
                    Console.ForegroundColor = letter.Item2;



                    //Write text of a letter
                    Console.Write(letter.Item1);
                }
                Console.WriteLine();
            }
            Console.ResetColor();

        }



    }
    //Maybe, should use it for some roguelike
}
