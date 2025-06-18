namespace InitiativeTracker.Classes
{
    public class CharacterClass
    {
        public int id;
        public string name;
        public string characterImageUrl = "https://www.dndbeyond.com/avatars/44177/291/1581111423-125044981.jpeg?width=150&height=150&fit=crop&quality=95&auto=webp";
        public Armor? helm;
        public Clothing? cape;
        public Armor? chest;
        public Armor? gloves;
        public Armor? boots;
        public Ring? ringOne;
        public Ring? ringTwo;
        public Necklace? necklace;
        public Melee? mainMelee;
        public Melee? offMelee;
        public Ranged? mainRanged;
        public Ranged? offRanged;

        public CharacterClass()
        {

        }

    }
}
