using System;
using System.Collections.Generic;
using System.Linq;
using Khegay.Nsudotnet.TicTacToe.Display;
using Khegay.Nsudotnet.TicTacToe.Model;
using Khegay.Nsudotnet.TicTacToe.Views;

namespace Khegay.Nsudotnet.TicTacToe
{
    class Game
    {
        private readonly ConsoleDisplay _display = new ConsoleDisplay();
        private readonly Field _field = new Field();
        private readonly PlayerNameView _xView;
        private readonly PlayerNameView _oView;
        private readonly TextView _inputView;
        private readonly TextView _victoryView;
        private bool _inverseInput;

        public Game()
        {
            _display.Add(5,5, new FieldView(_field));
            _display.Add(5,2,_victoryView = new AlignedTextView(32, AlignedTextView.Align.Center));
            _display.Add(5, 4,
                _xView =
                    new PlayerNameView(9, AlignedTextView.Align.Left, Program.XColor, Program.XColorPassive).SetName("Player X"));
            _display.Add(15, 4,
                _oView =
                    new PlayerNameView(9, AlignedTextView.Align.Right, Program.OColor, Program.OColorPassive).SetName("Player O"));
            _display.Add(30, 11, _inputView = new StaticTextView());
            UpdateInputView();
            _display.Add(45, 8, new MultilineTextView(20).SetLines(
                "Commands:",
                "1-9 - make a move",
                "r - restart",
                "i - inverse numeric mapping ",
                "q - quit"));
        }

        public void Start()
        {
            Console.Title = "TicTacToe^2";
            UpdatePlayerName();
            while (true)
            {
                _display.Draw();
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.R:
                        Restart();
                        continue;
                    case ConsoleKey.I:
                        _inverseInput = !_inverseInput;
                        UpdateInputView();
                        continue;
                    case ConsoleKey.Q:
                        return;
                }
                if (char.IsDigit(key.KeyChar))
                {
                    Step(key.KeyChar - '0');
                }
            }
        }

        private void Restart()
        {
            _field.Reset();
            UpdatePlayerName();
        }

        private void Step(int num)
        {
            if (_field.Draw || _field.Victory != Mark.No) return;
            if (num == 0) return;
            _field.Step((num - 1) % 3, _inverseInput ? 2 - (num - 1) / 3 : (num - 1) / 3);
            if (_field.Draw)
            {
                _victoryView.Color = ConsoleColor.Gray;
                _victoryView.SetLines("DRAW".ExtendWithSpaces());
                return;
            }
            if (_field.Victory == Mark.X)
            {
                _victoryView.Color = Program.XColor;
                _victoryView.SetLines("PLAYER X WINS".ExtendWithSpaces());
                return;
            }
            if (_field.Victory == Mark.O)
            {
                _victoryView.Color = Program.OColor;
                _victoryView.SetLines("PLAYER O WINS".ExtendWithSpaces());
                return;
            }
            UpdatePlayerName();
        }

        

        private void UpdatePlayerName()
        {
            _xView.Active = _field.Player == Mark.X;
            _oView.Active = _field.Player == Mark.O;
        }

        private void UpdateInputView()
        {
            if (!_inverseInput)
            {
                _inputView.SetLines(
                    "+-+-+-+",
                    "|1|2|3|",
                    "+-+-+-+",
                    "|4|5|6|",
                    "+-+-+-+",
                    "|7|8|9|",
                    "+-+-+-+");
            }
            else
            {

                _inputView.SetLines(
                    "+-+-+-+",
                    "|7|8|9|",
                    "+-+-+-+",
                    "|4|5|6|",
                    "+-+-+-+",
                    "|1|2|3|",
                    "+-+-+-+");
            }
        }
    }
}
