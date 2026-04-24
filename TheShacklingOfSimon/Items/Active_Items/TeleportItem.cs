#region

using System;
using Microsoft.Xna.Framework;
using TheShacklingOfSimon.Entities;
using TheShacklingOfSimon.Rooms_and_Tiles.Rooms.RoomClass;
using TheShacklingOfSimon.Sounds;

#endregion

namespace TheShacklingOfSimon.Items.Active_Items;

public class TeleportItem : ActiveItem, IInventoryItem
{
    private readonly string _sfx;
    private float _timer;
    private readonly float _cooldownDuration;
    private bool _buffActive;

    private readonly Func<TileMap> _tileMapProvider;

    private readonly float _blinkDistance;
    private readonly float _step; // Used to walk backward from the target if the destination is invalid.

    public TeleportItem(
        IDamageableEntity entity,
        Func<TileMap> tileMapProvider,
        float blinkDistance = 96f,
        float cooldownSeconds = 2.0f,
        float step = 8f)
        : base(entity)
    {
        Entity = entity ?? throw new ArgumentNullException(nameof(entity));
        _tileMapProvider = tileMapProvider ?? throw new ArgumentNullException(nameof(tileMapProvider));

        _blinkDistance = Math.Max(0f, blinkDistance);
        _cooldownDuration = Math.Max(0f, cooldownSeconds);
        _step = Math.Max(1f, step);

        Name = "Blink";
        Description = "Teleports you a short distance forward.";

        _sfx = SoundManager.Instance.AddSFX("items", "warp");
    }

    public override void Update(GameTime gameTime)
    {
        if (!_buffActive) return;

        _timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (_timer <= 0f)
        {
            _timer = 0f;
            _buffActive = false;
        }
    }

    public override bool ApplyEffect()
    {
        if (_timer > 0f) return false;

        Vector2 direction = Entity.Velocity;

        if (direction.LengthSquared() < 0.0001f)
        {
            return false;
        }

        direction.Normalize();

        Vector2 start = Entity.Position;
        Vector2 target = start + direction * _blinkDistance;

        Vector2 candidate = target;
        float traveledBack = 0f;

        while (traveledBack <= _blinkDistance)
        {
            if (IsValidTeleportDestination(candidate))
            {
                if ((candidate - start).LengthSquared() < 0.0001f)
                {
                    return false;
                }

                Entity.SetPosition(candidate);

                _buffActive = true;
                _timer = _cooldownDuration;

                SoundManager.Instance.PlaySFX(_sfx);
                return true;
            }

            candidate -= direction * _step;
            traveledBack += _step;
        }

        return false;
    }

    private bool IsValidTeleportDestination(Vector2 candidatePosition)
    {
        if (!IsFinite(candidatePosition))
        {
            return false;
        }

        TileMap tileMap = _tileMapProvider();

        if (tileMap == null)
        {
            return false;
        }

        Rectangle candidateHitbox = GetCandidateHitbox(candidatePosition);

        if (!IsInsidePlayableRoomBounds(candidateHitbox, tileMap))
        {
            return false;
        }

        foreach (var tile in tileMap.GetTilesIntersecting(candidateHitbox))
        {
            if (tile.BlocksGround)
            {
                return false;
            }
        }

        return true;
    }

    private Rectangle GetCandidateHitbox(Vector2 candidatePosition)
    {
        Vector2 offset = candidatePosition - Entity.Position;

        return new Rectangle(
            (int)MathF.Round(Entity.Hitbox.X + offset.X),
            (int)MathF.Round(Entity.Hitbox.Y + offset.Y),
            Entity.Hitbox.Width,
            Entity.Hitbox.Height
        );
    }

    private static bool IsInsidePlayableRoomBounds(Rectangle hitbox, TileMap tileMap)
    {
        Rectangle roomBounds = tileMap.RoomBoundsWorld;

        // Exclude the 1-tile wall border. The player must stay inside the playable interior.
        Rectangle playableBounds = new Rectangle(
            roomBounds.X + RoomConstants.TileSize,
            roomBounds.Y + RoomConstants.TileSize,
            roomBounds.Width - RoomConstants.TileSize * 2,
            roomBounds.Height - RoomConstants.TileSize * 2
        );

        return hitbox.Left >= playableBounds.Left &&
               hitbox.Right <= playableBounds.Right &&
               hitbox.Top >= playableBounds.Top &&
               hitbox.Bottom <= playableBounds.Bottom;
    }

    private static bool IsFinite(Vector2 value)
    {
        return !float.IsNaN(value.X) &&
               !float.IsNaN(value.Y) &&
               !float.IsInfinity(value.X) &&
               !float.IsInfinity(value.Y);
    }
}