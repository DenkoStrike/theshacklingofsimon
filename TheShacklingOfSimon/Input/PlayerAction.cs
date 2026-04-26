namespace TheShacklingOfSimon.Input;

public enum PlayerAction
{
    // Movement
    MoveUp, MoveDown, MoveLeft, MoveRight,
    
    // Attacking
    PrimaryAttackUp, PrimaryAttackLeft, PrimaryAttackRight, PrimaryAttackDown,
    SecondaryAttackUp, SecondaryAttackLeft, SecondaryAttackRight, SecondaryAttackDown,
    
    // Rotary controls
    NextPrimaryWeapon, PreviousPrimaryWeapon, NextSecondaryWeapon, PreviousSecondaryWeapon,
    PreviousActiveItem, NextActiveItem,
    
    // Miscellaneous
    Pause, Resume, Quit, Reset
    
}