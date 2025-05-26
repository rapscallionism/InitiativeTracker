
public class Item
{
    public required string Description { get; set; }
    public required Tags Tags { get; set; }
    public required string OnAction { get; set; }
    public required string OnBonusAction { get; set; }
    public required string OnReaction { get; set; }
    public required string[] Effects { get; set; }
    public required ResetsOn ResetsOn { get; set; }
}

public class Tags
{
    public Rarity Rarity { get; set; }
    
    public EquipmentType EquipmentType { get; set; }
    public WeaponType? WeaponType { get; set; }
    public JewelryType? JewelryType { get; set; }
    public ArmorType? ArmorType { get; set; }
    public bool RequiresAttunement { get; set; }
}

public enum ResetsOn
{
    ALWAYS,
    SHORT_REST,
    LONG_REST,
    SINGLE_USE,
    CUSTOM
}

public enum EquipmentType
{
    ARMOR,
    WEAPON,
    JEWELRY
}

public enum ArmorType
{
    CLOTHING,
    LIGHT,
    MEDIUM,
    HEAVY
}

public enum WeaponType
{
    LONGSWORD,
    SHORTSWORD,
    GREATSWORD,
    BATTLEAXE,
    GREATAXE,
    DAGGER,
    QUARTERSTAFF
}

public enum JewelryType
{
    RING,
    NECKLACE
}

public enum Rarity
{
    COMMON,
    UNCOMMON,
    RARE,
    VERY_RARE,
    LEGENDARY
}