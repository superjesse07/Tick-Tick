using System;
using Microsoft.Xna.Framework;

public static class Camera
{
    private static Vector2 _position;
    private static float distance;
    private const float nauseaSpeed = 3;
    private const float nauseaMaxDistance = 100;

    public static Vector2 GetScreenPos(GameTime gameTime, Vector2 globalPosition, float parallaxSpeed = 1)
    {
        //check if the player has he nausea effect
        bool hasNausea = Effects.HasEffect(EffectType.NAUSEA, gameTime);
        //Calculate the distance the camera should move from the center
        distance = MathHelper.Clamp((float) (distance + gameTime.ElapsedGameTime.TotalSeconds * (hasNausea ? 1 : -1)), 0, nauseaMaxDistance);
        //Calculate the point in the circle the camera should be for the nausea effect
        Vector2 nausea = new Vector2((float) Math.Cos(gameTime.TotalGameTime.TotalSeconds * nauseaSpeed), (float) Math.Sin(gameTime.TotalGameTime.TotalSeconds * nauseaSpeed));

        return globalPosition - _position * new Vector2(parallaxSpeed, 1) + nausea * distance;
    }

    public static void SetPosition(Vector2 newPosition, Rectangle rectangle = default)
    {
        Vector2 screenSize = new Vector2(GameEnvironment.Screen.X, GameEnvironment.Screen.Y);
        _position = newPosition - screenSize / 2f;
        if (rectangle != default)
        {
            if (_position.X < rectangle.X) _position.X = rectangle.X;
            if (_position.Y < rectangle.Y) _position.Y = rectangle.Y;
            if (_position.X + screenSize.X > rectangle.X + rectangle.Width) _position.X = rectangle.X + rectangle.Width - screenSize.X;
            if (_position.Y + screenSize.Y > rectangle.Y + rectangle.Height) _position.Y = rectangle.Y + rectangle.Height - screenSize.Y;
        }
    }
}