using Examensarbete.PlayerMicroService.Shared.Enums;

namespace Examensarbete.PlayerMicroService.Data.Models;

public class PlayerInventory
{
    public Guid PlayerId { get; set; }
    public int MaxHearts { get; set; }
    public int CurrentHearts { get; set; }
    public int ExtraLives { get; set; }
    public int Coins { get; set; }
    public int Keys { get; set; }
    public bool HasBigKey { get; set; }
    public List<ConsumableItem> ConsumableItems { get; set; } = new List<ConsumableItem>();
    public List<KeyItem> Items { get; set; } = new List<KeyItem>();
    public List<Egg> Eggs { get; set; } = new List<Egg>();
    public List<FoodYummY> FoodYummies { get; set; } = new List<FoodYummY>();
    public List<Curse> Curses { get; set; } = new List<Curse>();
}