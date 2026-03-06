namespace Examensarbete.PlayerMicroService.Shared.Enums;
public enum Item
{
    GravityGurka, // when grounded, lets you change the gravity in any direction for a short time
    Lantern, // lights up dark areas and reveals hidden secrets
    BookOfShadows, // the player stops for a few seconds, reading outloud from the book. During this time, if 
                   // standing in the right place, might reveal hidden secrets or open secret passages.
}

public enum Egg
{
    PickledEgg,
    SquareEgg,
    PolkaDotEgg,
    GenderEgg,
    XellentEgg,
    AutumnEgg,
}

public enum FoodYummies // random drops from enemies and environment - gives you points
{
    Carrot,
    Apple,
    Banana,
    CakeSlice,
    PrincessCake,
    ChocolateCookie,
}

public enum ConsumableItem // items dropped by enemies that give an instant effect (often for a short period)
{
    RaceCar, // makes you really fast 
    Shield, // blocks all damage for 3 hits then breaks
    GiantGrowth, // you become larger, and can walk over enemies to kill them
    ExtraLife,
    CarrotJuice, // Heals the player for a small amount of HP
    StopWatch, // Freezes the time

}

public enum Curses // curses you, but gives you points at the same time
{
    Slowness,
    Fragility, // Takes double damage
    Drunk, // blurred vision and occasional jump after random hiccups
    Confusion, // controls are reversed
    Sleep, // cannot move or interact for a short time
}