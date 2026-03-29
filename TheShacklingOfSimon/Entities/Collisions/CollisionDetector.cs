#region

using Microsoft.Xna.Framework;

#endregion

namespace TheShacklingOfSimon.Entities.Collisions;

public static class CollisionDetector
{
    public static bool CheckRectangleCollision(Rectangle r1, Rectangle r2)
    {
        return r1.Intersects(r2);
    }

    public static Vector2 CalculateMinimumTranslationVector(Rectangle r1, Rectangle r2)
    {
        Rectangle intersection = Rectangle.Intersect(r1, r2);
        if (intersection.IsEmpty)
        {
            return Vector2.Zero;
        }

        Vector2 result;
        if (intersection.Width < intersection.Height)
        {
            float direction = (r1.Center.X < r2.Center.X) ? -1.0f : 1.0f;
            result = new Vector2(intersection.Width * direction, 0);
        }
        else
        {
            float direction = (r1.Center.Y < r2.Center.Y) ? -1.0f : 1.0f;
            result = new Vector2(0, intersection.Height * direction);
        }

        return result;
    }
    
    public static CollisionSide GetCollisionSideFromRectangles(Rectangle r1, Rectangle r2)
    {
        Vector2 mtv = CalculateMinimumTranslationVector(r1, r2);
        return GetCollisionSide(mtv);
    }
    
    public static CollisionSide GetCollisionSideFromMtv(Vector2 mtv)
    {
        return GetCollisionSide(mtv);
    }

    private static CollisionSide GetCollisionSide(Vector2 mtv)
    {
        CollisionSide side = CollisionSide.None;
        
        
        /*
         * mtv.X negative => collision on right side
         * mtv.X positive => collision on left side
         * mtv.Y negative => collision on bottom side
         * mtv.Y positive => collision on top side
         */
        if (mtv.X < -float.Epsilon)
        {
            side = CollisionSide.Right;
        }
        else if (mtv.X > float.Epsilon)
        {
            side = CollisionSide.Left;
        }
        else if (mtv.Y < -float.Epsilon)
        {
            side = CollisionSide.Bottom;
        }
        else if (mtv.Y > float.Epsilon)
        {
            side = CollisionSide.Top;
        }

        return side;
    }
}