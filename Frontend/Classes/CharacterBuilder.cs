using System.Runtime.CompilerServices;

namespace Frontend.Classes
{
    public class CharacterBuilder
    {
        private int id;
        private string name;
        private string characterImageUrl = "";
        private Armor? helm;
        private Clothing? cape;
        private Armor? chest;
        private Armor? gloves;
        private Armor? boots;
        private Ring? ringOne;
        private Ring? ringTwo;
        private Necklace? necklace;
        private Melee? mainMelee;
        private Melee? offMelee;
        private Ranged? mainRanged;
        private Ranged? offRanged;

        public CharacterBuilder Id(int id)
        {
            this.id = id;
            return this;
        }

        public CharacterBuilder Name(string name)
        {
            this.name = name;
            return this;
        }

        public CharacterBuilder CharacterImageUrl(string url)
        {
            characterImageUrl = url;
            return this;
        }

        public CharacterBuilder Helm(Armor helm)
        {
            this.helm = helm;
            return this;
        }

        public CharacterBuilder Cape(Clothing cape)
        {
            this.cape = cape;
            return this;
        }

        public CharacterBuilder Chest(Armor chest)
        {
            this.chest = chest;
            return this;
        }

        public CharacterBuilder Gloves(Armor gloves)
        {
            this.gloves = gloves;
            return this;
        }

        public CharacterBuilder Boots(Armor boots)
        {
            this.boots = boots;
            return this;
        }

        public CharacterBuilder RingOne(Ring ringOne)
        {
            this.ringOne = ringOne;
            return this;
        }

        public CharacterBuilder RingTwo(Ring ringTwo)
        {
            this.ringTwo = ringTwo;
            return this;
        }

        public CharacterBuilder Necklace(Necklace necklace)
        {
            this.necklace = necklace;
            return this;
        }

        public CharacterBuilder MainMelee(Melee mainMelee)
        {
            this.mainMelee = mainMelee;
            return this;
        }

        public CharacterBuilder OffMelee(Melee offMelee)
        {
            this.offMelee = offMelee;
            return this;
        }

        public CharacterBuilder MainRanged(Ranged mainRanged)
        {
            this.mainRanged = mainRanged;
            return this;
        }

        public CharacterBuilder OffRanged(Ranged offRanged)
        {
            this.offRanged = offRanged;
            return this;
        }
        public CharacterClass Build()
        {
            return new CharacterClass()
            {
                id = id,
                name = name,
                helm = helm,
                cape = cape,
                chest = chest,
                gloves = gloves,
                boots = boots,
                ringOne = ringOne,
                ringTwo = ringTwo,
                necklace = necklace,
                mainMelee = mainMelee,
                offMelee = offMelee,
                mainRanged = mainRanged,
                offRanged = offRanged,
            };

        }
    }
}
