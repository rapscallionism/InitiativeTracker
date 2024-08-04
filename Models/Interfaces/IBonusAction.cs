namespace Turn_Based_Game.Models.Interfaces
{
    public interface IBonusAction
    {
        public string _name { get; set; }
        public string _description { get; set; }

        /// <summary>
        ///     Represents the number of times that this action can be used. By default, should be set to -1 (meaning can be repeated infinite number of times)
        ///     and has no limit. An example of this would be the attack action. Anything else other than that means that the action can only be used
        ///     by the certain amount defined by this attribute. 
        /// </summary>
        public int _numberOfUses { get; set; }

        /// <summary>
        ///     Represents the maximum number of times that this action can be used. Mainly used for reference to identify the amount of times time an
        ///     action can be used as well as to keep tabs on what <c>_numberOfUses</c> can be reset to 
        /// </summary>
        public int _maxNumberOfUses { get; set; }
    }
}
