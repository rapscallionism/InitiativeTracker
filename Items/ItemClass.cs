namespace InitiativeTracker.Items
{
    public abstract class ItemClass
    {
        public String Description = "";
        public Tags Tags = new Tags();
        public String onAction = "";
        public String onBonusAction = "";
        public String onReaction = "";
        public List<String> Effects = new List<String>();
        public ResetsOn ResetsOn;
    }
}
