namespace Turn_Based_Game.Components
{
    public class Creature
    {
        public string _name = "";
        public int _initiative = 0;
        public bool _isCurrentTurn = false;
        public bool _hasMovement = true;
        public bool _hasBonusAction = true;
        public bool _hasAction = true;
        public bool _hasReaction = true;
        /// <summary>
        ///     1 = Alive
        ///     0 = Unconscious
        ///     -1 = Dead
        /// </summary>
        public int _isDead = 1;
        public int _currentHealth = 0;
        public bool _isCurrentlyChangingHealth = false;
        public int _damageTaken = 0;
        public int _damageHealed = 0;

        public Creature() { }

        public Creature(string name, int initiative, int currentHealth)
        {
            _name = name;
            _initiative = initiative;
            _currentHealth = currentHealth;
        }

        public void Reset()
        {
            _hasMovement = true;
            _hasBonusAction = true;
            _hasAction = true;
            _hasReaction = true;
        }

        public void UseMovement()
        {
            this._hasMovement = false;
        }

        public void UseAction()
        {
            this._hasAction = false;
        }

        public void UseBonusAction()
        {
            this._hasBonusAction = false;
        }

        public void UseReaction()
        {
            this._hasReaction = false;
        }

        public void ResetMovement()
        {
            this._hasMovement = true;
        }

        public void ResetAction()
        {
            this._hasAction = true;
        }

        public void ResetBonusAction()
        {
            this._hasBonusAction = true;
        }

        public void ResetReaction()
        {
            this._hasReaction = true;
        }

        public void UpdateDeathStatus()
        {
            if (this._isDead == -1)
            {
                this._isDead = 1;
            }
            else
            {
                this._isDead -= 1;
            }
        }

    }

}
