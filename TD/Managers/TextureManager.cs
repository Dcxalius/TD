using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TD
{
    static class TextureManager
    {

        public static Texture2D baseTower, uiBackground, pressedButton, unpressedButton, buildTower, background, foreground, gORBackground, road, goblin
            , arrow, rocket, freezeArrow, multiArrow, snipeArrow, superArrow, statusbar, statusbarNumbers, healthbar, selectedTower, targetedItem, 
            dataBox, towerButtonEmblem, damageButtonEmblem, rangeButtonEmblem, attackSpeedButtonEmblem, coinPurse, sniperEmblem, rocketEmblem, multishotEmblem, freezeEmblem, superEmblem, itemSlots;
        public static SpriteFont font;



        public static void LoadTex(ContentManager aContentManager)
        {
            font = aContentManager.Load<SpriteFont>("Font");
            baseTower = aContentManager.Load<Texture2D>("Tower");
            uiBackground = aContentManager.Load<Texture2D>("UIBackground");
            pressedButton = aContentManager.Load<Texture2D>("PressedButton");
            unpressedButton = aContentManager.Load<Texture2D>("UnpressedButton");
            buildTower = aContentManager.Load<Texture2D>("buildTower");
            background = aContentManager.Load<Texture2D>("Background");
            foreground = aContentManager.Load<Texture2D>("Foreground");
            gORBackground = aContentManager.Load<Texture2D>("GORBackground");
            road = aContentManager.Load<Texture2D>("Road");
            goblin = aContentManager.Load<Texture2D>("Goblin");
            arrow = aContentManager.Load<Texture2D>("Arrow");
            rocket = aContentManager.Load<Texture2D>("Rocket");
            freezeArrow = aContentManager.Load<Texture2D>("FreezeArrow");
            multiArrow = aContentManager.Load<Texture2D>("MultiArrow");
            snipeArrow = aContentManager.Load<Texture2D>("snipeArrow");
            superArrow = aContentManager.Load<Texture2D>("superarrow");
            statusbar = aContentManager.Load<Texture2D>("statusbar");
            statusbarNumbers = aContentManager.Load<Texture2D>("statusbarNumbers");
            healthbar = aContentManager.Load<Texture2D>("healthbar");
            selectedTower = aContentManager.Load<Texture2D>("selectedTower");
            dataBox = aContentManager.Load<Texture2D>("Databox");
            towerButtonEmblem = aContentManager.Load<Texture2D>("towerButtonEmblem");
            damageButtonEmblem = aContentManager.Load<Texture2D>("damageButtonEmblem");
            rangeButtonEmblem = aContentManager.Load<Texture2D>("rangeButtonEmblem");
            attackSpeedButtonEmblem = aContentManager.Load<Texture2D>("attackSpeedButtonEmblem");
            coinPurse = aContentManager.Load<Texture2D>("Coinpurse");
            sniperEmblem = aContentManager.Load<Texture2D>("sniperEmblem");
            rocketEmblem = aContentManager.Load<Texture2D>("rocketEmblem");
            multishotEmblem = aContentManager.Load<Texture2D>("multishotEmblem");
            freezeEmblem = aContentManager.Load<Texture2D>("freezeEmblem");
            superEmblem = aContentManager.Load<Texture2D>("superEmblem");
            itemSlots = aContentManager.Load<Texture2D>("itemSlots");
            targetedItem = aContentManager.Load<Texture2D>("TargetedItem");
        }
    }
}