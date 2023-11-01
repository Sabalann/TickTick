using Engine;
using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Represents a rocket enemy that flies horizontally through the screen.
/// </summary>
class Rocket : AnimatedGameObject
{
    Level level;
    Vector2 startPosition;
    const float speed = 500;

    public Rocket(Level level, Vector2 startPosition, bool facingLeft) 
        : base(TickTick.Depth_LevelObjects)
    {
        this.level = level;

        LoadAnimation("Sprites/LevelObjects/Rocket/spr_rocket@3", "rocket", true, 0.1f);
        PlayAnimation("rocket");
        SetOriginToCenter();

        sprite.Mirror = facingLeft;
        if (sprite.Mirror)
        {
            velocity.X = -speed;
            this.startPosition = startPosition + new Vector2(2*speed, 0);
        }
        else
        {
            velocity.X = speed;
            this.startPosition = startPosition - new Vector2(2 * speed, 0);
        }
        Reset();
    }

    public override void Reset()
    {
        // go back to the starting position
        LocalPosition = startPosition;
    }
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        // if the rocket has left the screen, reset it
        if (sprite.Mirror && BoundingBox.Right < level.BoundingBox.Left)
            Reset();
        else if (!sprite.Mirror && BoundingBox.Left > level.BoundingBox.Right)
            Reset();

        // dit stuk is herschreven 
        if (level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player)) // eerst checken of er collision plaats vindt
        {
            if ((level.Player.BoundingBox.Bottom) < startPosition.Y) // kijken of de onderkant van de speler zich boven de bovenkant van de bom bevindt
            {
                Reset(); // reset de bom
            }
            else // anders springt de speler niet bovenop de bom
            {
                level.Player.Die(); // speler gaat dood
            }
        }


    } 
}
