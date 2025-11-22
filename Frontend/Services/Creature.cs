namespace Frontend.Services
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
            _hasMovement = false;
        }

        public void UseAction()
        {
            _hasAction = false;
        }

        public void UseBonusAction()
        {
            _hasBonusAction = false;
        }

        public void UseReaction()
        {
            _hasReaction = false;
        }

        public void ResetMovement()
        {
            _hasMovement = true;
        }

        public void ResetAction()
        {
            _hasAction = true;
        }

        public void ResetBonusAction()
        {
            _hasBonusAction = true;
        }

        public void ResetReaction()
        {
            _hasReaction = true;
        }

        public void UpdateDeathStatus()
        {
            if (_isDead == -1)
            {
                _isDead = 1;
            }
            else
            {
                _isDead -= 1;
            }
        }

    }

}
