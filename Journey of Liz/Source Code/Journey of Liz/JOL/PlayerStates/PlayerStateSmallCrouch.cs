﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using JOL.Classes.PlayerClasses;
using JOL.Classes.ItemClasses;
using JOL.Interfaces;

namespace JOL.PlayerStates
{
    /// <summary>
    /// Crouch state of the small player.
    /// </summary>
    
    class PlayerStateSmallCrouch : PlayerState
    {
        public PlayerStateSmallCrouch(Player player) : base(player)
        {
            
        }

        public override void Left()
        {
            if (player.playerSprite.isFacingRight == false)
            {
                player.playerState = new PlayerStateSmallRunning(player);
                player.playerSprite = new PlayerSpriteSmallRunning(player.playerSprite);
            }
            else
                player.playerSprite.isFacingRight = false;
        }

        public override void Right()
        {
            if (player.playerSprite.isFacingRight == true)
            {
                player.playerState = new PlayerStateSmallRunning(player);
                player.playerSprite = new PlayerSpriteSmallRunning(player.playerSprite);
            }
            else
                player.playerSprite.isFacingRight = true;
        }

        public override void Up()
        {
            player.playerState = new PlayerStateSmallJumping(player);
            player.playerSprite = new PlayerSpriteSmallJumping(player.playerSprite);
        }

        public override void Hit()
        {
            player.playerState = new PlayerStateDead(player);
            player.playerSprite = new PlayerSpriteDead(player.playerSprite);
            player.myState = 0;
            player.level.lives--;
            player.level.dyingAnimation = true;
            player.MediaManager(2);
            player.playerSprite.soundInstance.Play();
        }

        public override void Collect(IItem item)
        {
            if (item is CheatPotionItem)
            {
                player.playerState = new PlayerStateCollectBlinking(player, new PlayerStateDemoCrouch(player));
                player.playerSprite = new TransitionSprite(player.playerSprite, new PlayerSpriteDemoCrouch(player.playerSprite), 1);
                player.myState = 3;
                player.playerSprite.soundInstance.Play();
            }
            else if (item is BardieEggItem)
            {
                player.playerState = new PlayerStateCollectBlinking(player, new PlayerStateRidingCrouch(player));
                player.playerSprite = new TransitionSprite(player.playerSprite, new PlayerSpriteRidingCrouch(player.playerSprite), 1);
                player.myState = 2;
                player.playerSprite.soundInstance.Play();
            }
            else if (item is DeathPotionItem)
            {
                player.playerState = new PlayerStateDead(player);
                player.playerSprite = new PlayerSpriteDead(player.playerSprite);
                player.myState = 0;
            }
        }
    }
}
