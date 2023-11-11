using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public static class Camera
    {
        public static Rectangle cameraview;
        public static Vector2 camerapos;
        public static Vector2 previous;
        
        public static void Updateoffset(Vector2 playerpos, int width, int height)
        {
            previous = camerapos;

            camerapos = new Vector2(playerpos.X - ExtendedGame.worldSize.X / 2, playerpos.Y - ExtendedGame.worldSize.Y / 2); // ervoor zorgen dat wanneer het kan, de speler in het midden staat
            camerapos.X = Math.Clamp(camerapos.X, 0, width - ExtendedGame.worldSize.X); // ervoor zorgen dat de camera altijd binnen de bounds van het leven zal vallen
            camerapos.Y = Math.Clamp(camerapos.Y, 0, height - ExtendedGame.worldSize.Y); // zelfde als hierboven maar in de hoogte
            cameraview = new Rectangle((int)camerapos.X, (int)camerapos.Y, ExtendedGame.worldSize.X, ExtendedGame.worldSize.Y); // bepalen hoe groot de camera is (in dit geval de eerder bepaalde windowsize)
            // worldSize gebruiken ipv windowSize want in de ExtendedGame schalen ze alles nog waardoor de windowSize gek doet
        }

        public static void CameraReset()
        {
            camerapos = new Vector2(0, 0);
            previous = camerapos;
        }

        public static bool CameraUpdate()
        {
            return camerapos != previous;
        }
    }
}