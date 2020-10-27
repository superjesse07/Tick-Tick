
    using Microsoft.Xna.Framework;

    public static class Camera
    {
        private static Vector2 _position;

        public static Vector2 GetScreenPos(Vector2 globalPosition,float parallaxSpeed = 1)
        {
            return globalPosition - _position * new Vector2(parallaxSpeed,1);
        }

        public static void SetPosition(Vector2 newPosition, Rectangle rectangle = default)
        {
            Vector2 screenSize = new Vector2(GameEnvironment.Screen.X,GameEnvironment.Screen.Y);
            _position = newPosition - screenSize/2f;
            if (rectangle != default)
            {
                if (_position.X < rectangle.X) _position.X = rectangle.X;
                if (_position.Y < rectangle.Y) _position.Y = rectangle.Y;
                if (_position.X + screenSize.X > rectangle.X + rectangle.Width) _position.X = rectangle.X + rectangle.Width - screenSize.X;
                if (_position.Y + screenSize.Y > rectangle.Y + rectangle.Height) _position.Y = rectangle.Y + rectangle.Height - screenSize.Y;
            }
        }
        
    }
