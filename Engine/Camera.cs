using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class Camera : GameObject
    {
        // GlobalPosition bepaald de positie van alle sprites in de gameworld
        // Als we de speler een parent maken van een ander object bewegen deze objecten met de speler mee
        // Niet daadwerkelijk de positie van de andere objecten aanpassen voor collission e.d, camera heeft alleen effect op het tekenen van objecten
        // een nieuwe vector aanmaken voor het tekenen zodat global position niet beinvloed word??

        // sowieso een update class voor de camera positie en de objecten die binnen de camera moeten
        // player in het midden?

        // ervoor zorgen dat de camera alleen werkt wanneer het nodig is, dus bijv. niet in het main menu


        public Rectangle cameraview;


        public Camera()
        {
            cameraview = new Rectangle((int)LocalPosition.X, (int)LocalPosition.Y, 800, 450);
           // Parent = ...;
        }






    }
}
