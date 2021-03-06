﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JOL.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace JOL.Classes.PlayerClasses
{
    class PlayerSpriteSmallCrouch : PlayerSprite
    {
        public PlayerSpriteSmallCrouch(IPlayerSprite previousSprite) : base(previousSprite)
        {
            sprite = contentManager.Load<Texture2D>("Liz/liz_idle");
            isMoving = false;
            isJumping = false;

            Initialize(previousSprite);
        }
    }
}
