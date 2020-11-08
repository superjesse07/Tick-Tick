using Microsoft.Xna.Framework;

namespace TickTick5.gameobjects
{
    public class EffectOverlayObject : SpriteGameObject
    {
        private readonly EffectType _effectType;
        public EffectOverlayObject(EffectType effectType,string assetName, int layer = 0, string id = "", int sheetIndex = 0, bool isScreenSpaceObject = false) : base(assetName, layer, id, sheetIndex, isScreenSpaceObject)
        {
            _effectType = effectType;
        }

        public override void Update(GameTime gameTime)
        {
            if (GameWorld.Find("player") is Player player) position = player.Position - new Vector2(0,player.Center.Y); //Move to the player position
            visible = Effects.HasEffect(_effectType, gameTime); // only show if the effect is active
        }
    }
}