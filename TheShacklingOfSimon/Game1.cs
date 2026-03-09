using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TheShacklingOfSimon.Commands;
using TheShacklingOfSimon.Commands.Item_Commands_and_Temporary_Manager;
using TheShacklingOfSimon.Commands.PlayerAttack;
using TheShacklingOfSimon.Commands.PlayerMovement;
using TheShacklingOfSimon.Commands.Room_Commands;
using TheShacklingOfSimon.Commands.Temporary_Commands;
using TheShacklingOfSimon.Controllers;
using TheShacklingOfSimon.Controllers.Keyboard;
using TheShacklingOfSimon.Controllers.Mouse;
using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.Entities.Collisions;
using TheShacklingOfSimon.Entities.Enemies;
using TheShacklingOfSimon.Entities.Enemies.EnemyTypes;
using TheShacklingOfSimon.Entities.Players;
using TheShacklingOfSimon.Entities.Projectiles;
using TheShacklingOfSimon.Input;
using TheShacklingOfSimon.Input.Keyboard;
using TheShacklingOfSimon.Input.Mouse;
using TheShacklingOfSimon.Items;
using TheShacklingOfSimon.Items.Active_Items;
using TheShacklingOfSimon.LevelHandler.Rooms.RoomClass;
using TheShacklingOfSimon.LevelHandler.Rooms.RoomConstructor;
using TheShacklingOfSimon.LevelHandler.Rooms.RoomManager;
using TheShacklingOfSimon.LevelHandler.Tiles;
using TheShacklingOfSimon.Sprites.Factory;
using TheShacklingOfSimon.Weapons;
using KeyboardInput = TheShacklingOfSimon.Controllers.Keyboard.KeyboardInput;

namespace TheShacklingOfSimon;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _texture;
    private SpriteFont _font;
    
    private IController<KeyboardInput> _keyboardController;
    private IController<MouseInput> _mouseController;

    private RoomManager _roomManager; //room manager for sprint 3
    private ItemManager _itemManager; //Temporary item switching for sprint 2
    private InputManager _inputManager;

    private IPlayer _player;
    private List<IEntity> _entities;
    private ProjectileManager _projectileManager; //_projectileManager = new ProjectileManager();
    private CollisionBulkLoader _collisionBulkLoader;
    private CollisionManager _collisionManager;

    // Entities that should always be registered as dynamic colliders regardless of room
    private readonly List<IEntity> _persistentDynamicEntities = new();

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _keyboardController = new KeyboardController(new MonoGameKeyboardService());
        _mouseController = new MouseController(new MonoGameMouseService());
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Rectangle screenDimensions = GraphicsDevice.Viewport.Bounds;

        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // Create Content pipeline 
        _font = Content.Load<SpriteFont>("File");

        // Load Player Sprites into factory 
        SpriteFactory.Instance.LoadTexture(Content, "PlayerDefaultSprite.json", "player");

        // Load Enemy Sprites into factory
        SpriteFactory.Instance.LoadTexture(Content, "SpiderEnemy.json", "SpiderEnemy");
        SpriteFactory.Instance.LoadTexture(Content, "BlackMaw.json", "BlackMaw");

        // Load Projectile Sprites and Manager_projectileManager.Update(delta);
        _projectileManager = new ProjectileManager();

        //load Tile Sprites and room Manager
        SpriteFactory.Instance.LoadTexture(Content, "images/Rocks.json", "images/Rocks");
        SpriteFactory.Instance.LoadTexture(Content, "images/Spikes.json", "images/Spikes");
        SpriteFactory.Instance.LoadTexture(Content, "images/Fire.json", "images/Fire");
        SpriteFactory.Instance.LoadTexture(Content, "images/RoomBackground.json", "images/RoomBackground");

        var roomReader = new JsonRoomReader(Content);
        var indexReader = new RoomIndexReader(Content);
        var roomFactory = new RoomFactory();
        _roomManager = new RoomManager(roomReader, indexReader, roomFactory, GraphicsDevice, preserveRoomState: true);

        // Create entities now that the sprite factory has textures
        _entities = new List<IEntity>();
        _player = new PlayerWithTwoSprites(new Vector2(screenDimensions.Width * 0.5f, screenDimensions.Height * 0.5f));
        _entities.Add(_player);

        IWeapon basicWeapon = new BasicWeapon(_projectileManager);
        IWeapon bombWeapon = new BombWeapon(_projectileManager);

        _player.AddWeaponToInventory(basicWeapon);
        _player.EquipPrimaryWeapon(0);

        _player.AddWeaponToInventory(bombWeapon);
        _player.EquipSecondaryWeapon(1);

        // temporary items for demo
        _player.AddItemToInventory(new TeleportItem(_player, pos => true));
        _player.AddItemToInventory(new AdrenalineItem(_player));


        //load Item Sprites and manager
        SpriteFactory.Instance.LoadTexture(Content, "images/8Ball.json", "images/8Ball");
        SpriteFactory.Instance.LoadTexture(Content, "images/Red_Heart.json", "images/Red_Heart");

        _itemManager = new ItemManager(_player, SpriteFactory.Instance);

        // Register controls now that the player exists
        _inputManager = new InputManager(
            _keyboardController,
            _mouseController,
            _player, 
            this, 
            _roomManager, 
            _itemManager,
            Reset
        );
        _inputManager.LoadDefaultControls();

        _collisionManager = new CollisionManager();

        // Persistent dynamic colliders (demo setup)
        _persistentDynamicEntities.Clear();
        _persistentDynamicEntities.Add(_player);

        /*
         * Subscribe the collision manager to the event of a new projectile
         * being created from basicWeapon and bombWeapon
         */
        basicWeapon.OnProjectileFired += _collisionManager.AddDynamicEntity;
        bombWeapon.OnProjectileFired += _collisionManager.AddDynamicEntity;

        // Re-register collidables whenever the room changes
        _collisionBulkLoader = new CollisionBulkLoader(_collisionManager, _persistentDynamicEntities);
        _roomManager.RoomChanged += _collisionBulkLoader.RegisterRoomCollidables;

        // Register current room (starting room) once
        _collisionBulkLoader.RegisterRoomCollidables(_roomManager.CurrentRoom);

        // TODO: Can add projectile manager subscriptions here
        foreach (IEntity entity in _roomManager.CurrentRoom.Entities)
        {
            if (entity is IEnemy enemy)
            {
                enemy.SetProjectileManager(_projectileManager);
            }
        }
        // Or really any spot after the weapons are created
    }

    protected override void Update(GameTime delta)
    {
        _keyboardController.Update();
        _mouseController.Update();

        _projectileManager.Update(delta);
        _roomManager.Update(delta);
        _itemManager.Update(delta);
        _player.CurrentItem?.Update(delta);

        foreach (IEntity e in _entities)
        {
            e.Update(delta);
        }

        // Enable once all collidable entities have non-throwing OnCollision implementations
        _collisionManager.Update(delta); 

        base.Update(delta);
    }

    protected override void Draw(GameTime delta)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
        GraphicsDevice.Clear(Color.Black);

        _roomManager.Draw(_spriteBatch);
        _itemManager.Draw(_spriteBatch);
        _projectileManager.Draw(_spriteBatch);

        foreach (IEntity e in _entities)
        {
            e.Draw(_spriteBatch);
        }

        _spriteBatch.End();
        base.Draw(delta);
    }

    // Master reset method
    private void Reset()
    {
        Rectangle screenDimensions = GraphicsDevice.Viewport.Bounds;
        
        _player.Reset(new Vector2(screenDimensions.Width * 0.5f, screenDimensions.Height * 0.5f));
        
        // TODO: Load starting room here again
        
        // Now rebuild collision lists for starting room
        _collisionBulkLoader.RegisterRoomCollidables(_roomManager.CurrentRoom);
    }
}