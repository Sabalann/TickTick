using Engine;
using Engine.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class TitleMenuState : GameState
{
    Button playButton, helpButton;
    Switch musicbutton;

    public TitleMenuState()
    {
        // load the title screen
        SpriteGameObject titleScreen = new SpriteGameObject("Sprites/Backgrounds/spr_title", TickTick.Depth_Background);
        gameObjects.AddChild(titleScreen);

        // add a play button
        playButton = new Button("Sprites/UI/spr_button_play@2", TickTick.Depth_UIForeground);
        playButton.LocalPosition = new Vector2(600, 540);
        gameObjects.AddChild(playButton);

        // add a help button
        helpButton = new Button("Sprites/UI/spr_button_help@2", TickTick.Depth_UIForeground);
        helpButton.LocalPosition = new Vector2(600, 600);
        gameObjects.AddChild(helpButton);

        // add music button
        musicbutton = new Switch("Sprites/UI/spr_button_music@2x2", TickTick.Depth_UIForeground);
        musicbutton.LocalPosition = new Vector2(0, titleScreen.Height - musicbutton.Height);
        gameObjects.AddChild(musicbutton);

        
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (playButton.Pressed)
            ExtendedGame.GameStateManager.SwitchTo(ExtendedGameWithLevels.StateName_LevelSelect);
        else if (helpButton.Pressed)
            ExtendedGame.GameStateManager.SwitchTo(ExtendedGameWithLevels.StateName_Help);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (musicbutton.Selected) { MediaPlayer.Pause(); }
        else MediaPlayer.Resume();
    }
}