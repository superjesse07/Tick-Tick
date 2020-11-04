using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


public class ParallaxGameObject : SpriteGameObject
{
    private float _parallaxSpeed;

    public ParallaxGameObject(string assetName, float parallaxSpeed, int layer = 0, string id = "", int sheetIndex = 0, bool isScreenSpaceObject = false) : base(assetName, layer, id, sheetIndex, isScreenSpaceObject)
    {
        _parallaxSpeed = parallaxSpeed;
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (!visible || sprite == null)
        {
            return;
        }

        sprite.Draw(spriteBatch, isScreenSpaceObject ? GlobalPosition : Camera.GetScreenPos(gameTime,GlobalPosition, _parallaxSpeed), origin);
    }
}