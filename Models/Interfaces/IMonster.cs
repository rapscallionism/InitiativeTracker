namespace Turn_Based_Game.Models.Interfaces
{
    public interface IMonster : ICreature
    {
        /// <summary>
        ///     Attribute containing the description information for this monster
        /// </summary>
        public string _description { get; set; }

        /// <summary>
        ///     Method to print out the description to the console
        /// </summary>
        public void printDescription();
    }
}
