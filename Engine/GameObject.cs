using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    public class GameObject : IGameLoopObject
    {
        /// <summary>
        /// The position of this game object, relative to its parent in the game-object hierachy.
        /// </summary>
        public Vector2 LocalPosition
        {
            get { return localPosition; }
            set { localPosition = value; }
        }
        protected Vector2 localPosition;

        /// <summary>
        /// The current velocity of this game object, in units per second.
        /// </summary>
        protected Vector2 velocity;

        /// <summary>
        /// Whether or not this game object is currently visible.
        /// </summary>
        public bool Visible { get; set; }
        public bool Moving { get; set; } // bepaald of een object mee moet bewegen of niet
        public bool Parallax1 { get; set; } // eerste laag parallax
        public bool Parallax2 { get; set; } // tweede laag parallax

        /// <summary>
        /// The (optional) parent of this object in the game-object hierarchy.
        /// If the object has a parent, then its position depends on its parent's position.
        /// </summary>
        public GameObject Parent { get; set; }

        /// <summary>
        /// Creates a new GameObject.
        /// </summary>
        public GameObject()
        {
            LocalPosition = Vector2.Zero;
            velocity = Vector2.Zero;
            Visible = true;
            Moving = true; // meeste bewegen mee, dus standaard op true
            Parallax1 = false; // alleen voor achtergronden, dus standaard op false
            Parallax2 = false;
        }

        /// <summary>
        /// Performs input handling for this GameObject. 
        /// By default, this method does nothing, but you can override it.
        /// </summary>
        /// <param name="inputHelper">An object with information about player input.</param>
        public virtual void HandleInput(InputHelper inputHelper)
        {
        }

        /// <summary>
        /// Updates this GameObject by one frame. 
        /// By default, this method updates the object's position according to its velocity.
        /// You can override this method to create your own custom behavior.
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed.</param>
        public virtual void Update(GameTime gameTime)
        {
            LocalPosition += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Parallax1 == true && Camera.CameraUpdate() == true) // kijk of object parallax heeft en of deze beweegt
                LocalPosition += new Vector2(5, 0) * (Camera.camerapos.X - Camera.previous.X) * (float)gameTime.ElapsedGameTime.TotalSeconds; // beweegt achterste objecten het snelst opzij

            if (Parallax2 == true && Camera.CameraUpdate() == true) // check if object has parallax and if camera moved
                LocalPosition += new Vector2(3,0) * (Camera.camerapos.X - Camera.previous.X) * (float)gameTime.ElapsedGameTime.TotalSeconds; // beweegt middelste objecten iets minder snel opzij
        }

        /// <summary>
        /// Draws this GameObject. By default, nothing happens, but other classes can override this method.
        /// </summary>
        /// <param name="gameTime">An object containing information about the time that has passed.</param>
        /// <param name="spriteBatch">The sprite batch to use.</param>
        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        /// <summary>
        /// Resets this game object to an initial state.
        /// For example, this can be useful for restarting a level of the game.
        /// Override this method so that it resets everything it needs to.
        /// </summary>
        public virtual void Reset()
        {
            velocity = Vector2.Zero;
        }

        /// <summary>
        /// Gets this object's global position in the game world, by adding its local position to the global position of its parent.
        /// </summary>
        public Vector2 GlobalPosition
        {
            get
            {
                if (Parent == null)
                    return LocalPosition;
                return LocalPosition + Parent.GlobalPosition;
            }
        }
    }
}