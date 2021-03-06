﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JOL.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JOL
{
    /// <summary>
    /// This camera can be used to follow a character.
    /// </summary>

    public class FollowCharacterCamera : ICamera
    {
        // Global variables
        public Vector2 Position { get; set; }

        private int height, width;
        private Vector2 characterPreviousPosition;
        private MultiPlayerHolder playerHolder;

        // Constructor
        public FollowCharacterCamera(MultiPlayerHolder playerHolder, int height, int width)
        {
            characterPreviousPosition = new Vector2(playerHolder.getCurrentMario().playerSprite.destRectangle.X, playerHolder.getCurrentMario().playerSprite.destRectangle.Bottom) ;
            Position = new Vector2(characterPreviousPosition.X- width/2 , characterPreviousPosition.Y - height*(5f/8f));
            
            this.playerHolder = playerHolder;
            this.height = height;
            this.width = width;
        }

        // Update is called every frame
        public void Update(GameTime gameTime)
        {
            float deltaX, deltaY;
            Vector2 characterCurrentPosition = new Vector2(playerHolder.getCurrentMario().playerSprite.destRectangle.X, playerHolder.getCurrentMario().playerSprite.destRectangle.Bottom);

            deltaY = characterPreviousPosition.Y - characterCurrentPosition.Y;
            deltaX = characterCurrentPosition.X - characterPreviousPosition.X;
            
            Position = new Vector2(Position.X + deltaX, Position.Y - deltaY);
            characterPreviousPosition = characterCurrentPosition;
        }

        public bool IsInView(Rectangle rectangle)
        {
            if (Position.X + width > rectangle.X && rectangle.X > Position.X)
            {
                if (Position.Y < rectangle.Y && Position.Y + height > rectangle.Y)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
