
    using System;
    using Microsoft.Xna.Framework;

    public static class Effects
    {
        public static double[] effects = new double[Enum.GetValues(typeof(EffectType)).Length];

        private static GameTime lastRecordedTime; // this is for all the times HasEffect will be called without knowing the elapsed time (like in player death) since has effect is called at least once for frame this should suffice
        
        public static void AddEffect(EffectType effectType,GameTime time,float length)
        {
            effects[(int) effectType] = time.TotalGameTime.TotalSeconds + length; // set the expiration time of the effect in the list
        }

        public static bool HasEffect(EffectType effectType,GameTime time)
        {
            lastRecordedTime = time;
            return effects[(int) effectType] > time.TotalGameTime.TotalSeconds; // check if the expiration time has happened yet
        }
        public static bool HasEffect(EffectType effectType)
        {
            return HasEffect(effectType, lastRecordedTime);
        }
        

        public static void Clear()
        {
            Array.Clear(effects,0,effects.Length);
        }
    }

    public enum EffectType
    {
        SWIFTNESS,
        SLOWNESS,
        BLINDNESS,
        FIRE_RESISTANCE,
        JUMP_BOOST,
        NAUSEA,
        RESISTANCE
    }