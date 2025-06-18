namespace InitiativeTracker.Classes
{
    public class CharacterClass
    {
        public int id;
        public string name;
        public string characterImageUrl = "https://cdn2.thecatapi.com/images/ebv.jpg";
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
