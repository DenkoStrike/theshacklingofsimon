#region

using System.Collections.Generic;

#endregion

namespace TheShacklingOfSimon.Sprites.Factory.Data;

// The root of the JSON structure.
public class SpriteDataRoot
{
    public List<SpriteData> Sprites { get; set; }
}