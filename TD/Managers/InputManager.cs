using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using WinForm;

namespace TD
{
    static class InputManager
    {


        public struct MyMouseState
        {
            public static MouseState oldMouseState;
            public static MouseState mouseState;


        }

        public struct MyKeyboardState
        {
            public static KeyboardState oldKeyboardState;
            public static KeyboardState keyboardState;
        }

        static public Vector2 MousePositionAsVector
        {
            get => MyMouseState.mouseState.Position.ToVector2();
        }

        static public Point MousePosition
        {
            get => MyMouseState.mouseState.Position;
        }

        public static void Update()
        {
            MyKeyboardState.oldKeyboardState = MyKeyboardState.keyboardState;
            MyKeyboardState.keyboardState = Keyboard.GetState();

            MyMouseState.oldMouseState = MyMouseState.mouseState;
            MyMouseState.mouseState = Mouse.GetState();

            

        }

        public static int AmountScrolledSinceLastFrame()
        {
            return MyMouseState.mouseState.ScrollWheelValue - MyMouseState.oldMouseState.ScrollWheelValue;
        }

        public static bool SingleLeftClick()
        {

            if (MyMouseState.mouseState.LeftButton == ButtonState.Pressed && MyMouseState.oldMouseState.LeftButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public static bool SingleLeftRelease()
        {

            if (MyMouseState.mouseState.LeftButton == ButtonState.Released && MyMouseState.oldMouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        public static bool SingleLeftClick(Rectangle aHitbox)
        {
            if (aHitbox.Contains(MousePosition) && SingleLeftClick())
            {
                return true;
            }

            return false;
        }

        public static bool SingleRightClick()
        {
            if (MyMouseState.mouseState.RightButton == ButtonState.Pressed && MyMouseState.oldMouseState.RightButton == ButtonState.Released)
            {
                return true;
            }
            return false;
        }

        public static bool SingleKeyPress(Keys aKey)
        {
            if (MyKeyboardState.keyboardState.IsKeyDown(aKey) && MyKeyboardState.oldKeyboardState.IsKeyUp(aKey))
            {
                return true;
            }
            return false;
        }

        public static Keys[] NumbersPressed()
        {
            List<Keys> listOfFreshKeys = new List<Keys>();
            foreach (Keys key in MyKeyboardState.keyboardState.GetPressedKeys())
            {
                if (MyKeyboardState.oldKeyboardState.IsKeyUp(key) && key >= Keys.NumPad0 && key <= Keys.NumPad9)
                {
                    listOfFreshKeys.Add(key);
                }
            }
            return listOfFreshKeys.ToArray();
        }
    }
}