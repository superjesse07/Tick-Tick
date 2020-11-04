
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Potion : SpriteGameObject
    {
        private SpriteSheet overlay;
        private Color _color;
        private EffectType _effectType;
        
        public Potion(Color color,EffectType effectType, int layer = 0, string id = "") : base ("Sprites/potion",layer,id)
        {
            _effectType = effectType;
            _color = color;
            overlay = new SpriteSheet("Sprites/potion_overlay");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!visible || sprite == null || overlay == null)
            {
                return;
            }
            sprite.Draw(spriteBatch, Camera.GetScreenPos(gameTime,GlobalPosition), origin);
            overlay.Draw(spriteBatch, Camera.GetScreenPos(gameTime,GlobalPosition), origin,_color);

        }
        
        public override void Update(GameTime gameTime)
        {
            double t = gameTime.TotalGameTime.TotalSeconds * 3.0f + Position.X;
            
            position.Y += (float)Math.Sin(t) * 0.2f;
            Player player = GameWorld.Find("player") as Player;
            if (visible && CollidesWith(player))
            {
                visible = false;
                GameEnvironment.AssetManager.PlaySound("Sounds/Minecraft_Drinking_Sound_Effect");
                Effects.AddEffect(_effectType,gameTime,10);
            }
        }
    }