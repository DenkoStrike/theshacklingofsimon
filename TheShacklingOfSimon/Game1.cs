using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheShacklingOfSimon;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        /*
         * Controls will be initialized here using RegisterCommand()
         * Use a Keys enum or MouseInput struct to register an input for mouse/keyboard
         * Then use some ICommand variable to register *what* that input does.
         *
         * e.g., _keyboardController.RegisterCommand(Keys.D0, new ExitCommand(this));
         * or _mouseController.RegisterCommand(
         *      new MouseInput(new Rectangle(0, 0, screenDimensions.Width, screenDimensions.Height), ButtonState.Pressed, MouseButton.Right), 
         *      new ExitCommand(this));
         * to register the D0 key and right click to exit the game.
         */
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
    
    public void SetSprite(int choice)
    {
        Rectangle screenDimensions = GraphicsDevice.Viewport.Bounds;
        Rectangle[] sprites = new Rectangle[]
        {
            // Rectangles for grabbing sprites off whatever spritesheets we decide to use
        };
        switch (choice)
        {
            // Add cases depending on how many sprites we have
        }
    }
}