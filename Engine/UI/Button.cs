﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine.UI
{
    /// <summary>
    /// A class that can represent a UI button in the game.
    /// </summary>
    public class Button : SpriteGameObject
    {
        /// <summary>
        /// Whether this button has been pressed (clicked) in the current frame.
        /// </summary>
        public bool Pressed { get; protected set; }
        protected bool hover; 

        /// <summary>
        /// Creates a new <see cref="Button"/> with the given sprite name and depth.
        /// </summary>
        /// <param name="assetName">The name of the sprite to use.</param>
        /// <param name="depth">The depth at which the button should be drawn.</param>
        public Button(string assetName, float depth) : base(assetName, depth)
        {
            Pressed = false;
        }
        public override void HandleInput(InputHelper inputHelper)
        {
            Pressed = Visible && inputHelper.MouseLeftButtonPressed()
                && BoundingBox.Contains(inputHelper.MousePositionWorld);
            if (this.BoundingBox.Contains(inputHelper.MousePositionWorld)) hover = true;
            else hover = false;
        }

        public override void Reset()
        {
            base.Reset();
            Pressed = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (hover) { this.SheetIndex = 1; }
            else { this.SheetIndex = 0; }
        }
    }
}