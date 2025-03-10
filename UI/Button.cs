﻿using RLNET;
using Tetris.Core;
using System;

namespace Tetris.UI
{
    public class Button : UIElement
    {
        public event EventHandler Click;

        public bool IsHovered { private get; set; }
        public RLColor BackgroundColor { private get; set; }

        private readonly bool _drawBorder;
        private readonly string _text;
        private readonly int _borderType;
        private RLColor _textColor;
        private RLColor _borderColor;

        public Button(int x, int y, int w, string text,
            RLColor textColor, RLColor borderColor, int borderType)
        {
            X = x;
            Y = y;
            Width = w;
            Height = 1;
            _text = text;
            _textColor = textColor;
            _borderColor = borderColor;
            IsHovered = false;
            _borderType = borderType;
            _drawBorder = true;
            BackgroundColor = RLColor.Black;
        }

        public Button(int x, int y, int w, string text,
            RLColor textColor, bool drawBorder)
        {
            X = x;
            Y = y;
            Width = w;
            Height = 1;
            _text = text;
            _textColor = textColor;
            _borderColor = Palette.Text;
            IsHovered = false;
            _drawBorder = drawBorder;
            BackgroundColor = RLColor.Black;
        }

        // draw button and border if enabled
        public override void Draw(RLConsole console)
        {
            RLColor textColor = _textColor;
            RLColor borderColor = _borderColor;
            if (IsHovered)
            {
                textColor -= 60;
                borderColor -= 60;
            }

            if (_drawBorder)
            {
                if (_borderType == 1)
                {
                    UserInterface.DrawSingleBorder(console, X, Y, Width, 1, borderColor);
                }
                else
                {
                    UserInterface.DrawDoubleBorder(console, X, Y, Width, 1, borderColor);
                }
            }

            console.Print(X, Y, _text, textColor, BackgroundColor);
        }

        // check if click is on button
        public void CheckClick(int x, int y)
        {
            if (IsInBounds(x, y))
            {
                OnClick();
            }
        }

        // check if mouse is hovering over button
        public void HandleHover(int x, int y)
        {
            IsHovered = IsInBounds(x, y);
        }

        // click event
        protected virtual void OnClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        // check if position is on button
        public bool IsInBounds(int x, int y)
        {
            if (_drawBorder)
            {
                return x >= X - 1 && x <= X + Width &&
                    y >= Y - 1 && y <= Y + Height;
            }
            else
            {
                return x >= X && x < X + Width &&
                    y >= Y && y < Y + Height;
            }
        }
    }
}