using System;
using System.Security.Principal;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TheShacklingOfSimon.Commands;
using TheShacklingOfSimon.Content.graphics;
using TheShacklingOfSimon.Controllers;
using TheShacklingOfSimon.Entities.Players;

namespace TheShacklingOfSimon;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;
    private SpriteFont _font;

    private IController<Keys> _keyboardController;
    private IController<MouseInput> _mouseController;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Rectangle screenDimensions = GraphicsDevice.Viewport.Bounds;

        IPlayer player =
            new PlayerWithTwoSprites(new Vector2(screenDimensions.Width * 0.5f, screenDimensions.Height * 0.5f));
        _keyboardController = new KeyboardController();
        _mouseController = new MouseController();
        
        /*
         * Controls are initialized here using RegisterCommand()
         * Use a Keys enum or MouseInput struct to register an input for mouse/keyboard
         * Then use some ICommand concrete class to register *what* that input does.
         *
         * e.g., _keyboardController.RegisterCommand(Keys.D0, new ExitCommand(this));
         * or _mouseController.RegisterCommand(
         *      new MouseInput(new Rectangle(0, 0, screenDimensions.Width, screenDimensions.Height), ButtonState.Pressed, MouseButton.Right), 
         *      new ExitCommand(this));
         * to register the D0 key and right click to exit the game.
         */
        // Movement controls
        _keyboardController.RegisterCommand(Keys.W, new MoveUpCommand(player));
        _keyboardController.RegisterCommand(Keys.A, new MoveLeftCommand(player));
        _keyboardController.RegisterCommand(Keys.S, new MoveRightCommand(player));
        _keyboardController.RegisterCommand(Keys.D, new MoveDownCommand(player));
        
        // Attacking controls
        _keyboardController.RegisterCommand(Keys.E, new SecondaryAttackNeutralCommand(player));
        _keyboardController.RegisterCommand(Keys.LeftShift, new SecondaryAttackNeutralCommand(player));
        _keyboardController.RegisterCommand(Keys.RightShift, new SecondaryAttackNeutralCommand(player));
        _keyboardController.RegisterCommand(Keys.Up, new PrimaryAttackUpCommand(player));
        _keyboardController.RegisterCommand(Keys.Left, new PrimaryAttackLeftCommand(player));
        _keyboardController.RegisterCommand(Keys.Down, new PrimaryAttackDownCommand(player));
        _keyboardController.RegisterCommand(Keys.Right, new PrimaryAttackRightCommand(player));
        
        _mouseController.RegisterCommand(
            new MouseInput(
                new Rectangle(0, 0, screenDimensions.Width, screenDimensions.Height),
                ButtonState.Pressed, 
                MouseButton.Right), 
            new SecondaryAttackNeutralCommand(player));
        _mouseController.RegisterCommand(
            new MouseInput(
                new Rectangle(0, 0, screenDimensions.Width, screenDimensions.Height),
                ButtonState.Pressed,
                MouseButton.Left),
            new PrimaryAttackDynamicMouseCommand(player)
            );
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");

        _mario = atlas.CreateAnimatedSprite("mario-idle");
        _mario.Scale = new Vector2(5.0f, 5.0f);
        _marioPosition.X = Window.ClientBounds.Width * 0.45f;
        _marioPosition.Y = Window.ClientBounds.Height * 0.45f;

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        _mario.Update(gameTime);

        CheckKeyboardInput();

        base.Update(gameTime);

    }

    private void CheckKeyboardInput()
    {
        
        KeyboardState keyboardState = Keyboard.GetState();
        MouseState mouseState = Mouse.GetState();

        if (keyboardState.IsKeyDown(Keys.D0) || keyboardState.IsKeyDown(Keys.NumPad0))
        {
            Exit();
        }
        if (keyboardState.IsKeyDown(Keys.D1) || keyboardState.IsKeyDown(Keys.NumPad1) || (mouseState.LeftButton == ButtonState.Pressed &&
        (mouseState.Position.X < Window.ClientBounds.Width * 0.5f && mouseState.Position.Y < Window.ClientBounds.Height * 0.5f)))
        {
            _currentAction = 1;
        }
        if (keyboardState.IsKeyDown(Keys.D2) || keyboardState.IsKeyDown(Keys.NumPad2) || (mouseState.LeftButton == ButtonState.Pressed &&
        (mouseState.Position.X >= Window.ClientBounds.Width * 0.5f && mouseState.Position.Y < Window.ClientBounds.Height * 0.5f)))
        {
            _currentAction = 2;
        }
        if (keyboardState.IsKeyDown(Keys.D3) || keyboardState.IsKeyDown(Keys.NumPad3) || (mouseState.LeftButton == ButtonState.Pressed &&
        (mouseState.Position.X < Window.ClientBounds.Width * 0.5f && mouseState.Position.Y >= Window.ClientBounds.Height * 0.5f)))
        {
            _currentAction = 3;
        }
        if (keyboardState.IsKeyDown(Keys.D4) || keyboardState.IsKeyDown(Keys.NumPad4) || (mouseState.LeftButton == ButtonState.Pressed &&
        (mouseState.Position.X >= Window.ClientBounds.Width * 0.5f && mouseState.Position.Y >= Window.ClientBounds.Height * 0.5f)))
        {
            _currentAction = 4;
        }
        DoAction();
    }

    private void DoAction()
    {
        if (_currentAction == 1)
        {
            _mario.Animation = atlas.GetAnimation("mario-idle");
        }
        if (_currentAction == 2)
        {
            if (_mario.Animation != atlas.GetAnimation("mario-twerk"))
            _mario.Animation = atlas.GetAnimation("mario-twerk");
        }
        if (_currentAction == 3)
        {
            if (_mario.Animation != atlas.GetAnimation("mario-run"))
            _mario.Animation = atlas.GetAnimation("mario-run");
            if (_marioVelocity)
            {
                _marioPosition.X += 15;
            } else
            {
                _marioPosition.X -= 15;
            }
            if (_marioPosition.X > Window.ClientBounds.Width || _marioPosition.X < 0)
            {
                _marioVelocity = !_marioVelocity;
            }

        }
        if (_currentAction == 4)
        {
            _mario.Animation = atlas.GetAnimation("mario-jump");
            if (_marioVelocity)
            {
                _marioPosition.Y += 15;
            } else
            {
                _marioPosition.Y -= 15;
            }
            if (_marioPosition.Y > Window.ClientBounds.Height || _marioPosition.Y < 0)
            {
                _marioVelocity = !_marioVelocity;
            }
        }
    }
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // Begin the sprite batch to prepare for rendering.

        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        SpriteFont font = Content.Load<SpriteFont>("Credits");
        
        _spriteBatch.DrawString(
            font,                   // font
            "Credits\nProgram Made By: Cameron Collins\nSprites from: https://www.mariouniverse.com/sprites-nes-smb/",     // text
            new Vector2(Window.ClientBounds.Width * 0.2f, Window.ClientBounds.Height * 0.7f),           // position
            Color.White             // color
        );

        _mario.Draw(
            _spriteBatch,
            _marioPosition
        );

        // Always end the sprite batch when finished.
        _spriteBatch.End();

        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }
}
