﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace SpaceSaver
{
    public class Explosion : Dynamic_Component
    {
        private float LifeTime;

        private double Timer;

        public Explosion(Dictionary<string, Animation> animations, Vector2 position) : base (animations, position)
        {
            Dynamic_Component_Initialization(animations, position);
            LifeTime = Animations.First().Value.FrameSpeed * Animations.First().Value.FrameCount;
            AnimationManager.Play(Animations["Action"]);
        }

        public override void Update(GameTime gameTime)
        {
            IsDead = (Timer += gameTime.ElapsedGameTime.TotalSeconds) >= LifeTime ? true : false;
            AnimationManager.Update(gameTime);
        }
    }
}
