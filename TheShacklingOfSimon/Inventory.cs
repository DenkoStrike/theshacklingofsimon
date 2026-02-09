using System.Collections.Generic;

namespace TheShacklingOfSimon;

public class Inventory
{
    public List<IWeapon> Weapons { get; private set; }
    public List<IItem> Items { get; private set; }
    
    public Inventory()
    {
        Weapons = new List<IWeapon>();
        Items = new List<IItem>();
    }
    
    public void AddWeapon(IWeapon w)
    {
        if (!Weapons.Contains(w))
        {
            Weapons.Add(w);
        }
    }

    public IWeapon RemoveWeapon(int pos)
    {
        if (pos < Weapons.Count)
        {
            Items.RemoveAt(pos);
        }
    }
    
    public void AddItem(IItem item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
        }
    }

    public IItem RemoveItem(int pos)
    {
        if (pos < Items.Count)
        {
            Items.RemoveAt(pos);
        }
    }
}