namespace Turn_Based_Game.Models.Interfaces
{
    public class Stat
    {
        public string _name { get; set; }
        public int _score { get; set; }
        public int _bonus { get; set; } = 0;
        public int _save { get; set; } = 0;

        public bool _hasBonusProficiency { get; set; } = false;
        public bool _hasSaveProficiency { get; set; } = false;

        public Stat(string name, int score, int bonus, int save) {
            _name = name;
            _score = score;
            _bonus = bonus;
            _save = save;
        }

        public Stat(string name, int score)
        {
            _name = name;
            _score = score;
            SetBonus();
            SetSave();
        }

        public Stat (string name, int score, bool hasBonusProficiency, bool hasSaveProficiency, int proficiencyBonus) {
            _name = name;
            _score = score;
            if (hasBonusProficiency) { SetBonus(proficiencyBonus); } else { SetBonus(); }
            if (hasSaveProficiency) { SetBonus(proficiencyBonus); } else { SetSave(); }
        }

        public void SetBonus() {
            // Algorithm is (math.floor(stat - 10))/2
            decimal calculation = _score - 10;
            _bonus = (int)Math.Floor(calculation);
        }

        public void SetBonus(int proficiencyBonus)
        {
            SetBonus();
            if (_hasBonusProficiency) { _bonus += proficiencyBonus; }
        }

        public void SetSave() {
            // Algorithm is (math.floor(stat - 10))/2
            decimal calculation = _score - 10;
            _save = (int)Math.Floor(calculation);
        }

        public void SetSave(int proficiencyBonus)
        {
            SetBonus();
            if (_hasSaveProficiency) { _save += proficiencyBonus; }
        }

        
    }
}
