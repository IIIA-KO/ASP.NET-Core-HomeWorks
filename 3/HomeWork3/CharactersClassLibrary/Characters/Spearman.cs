using CharactersClassLibrary.Printers;

namespace CharactersClassLibrary.Characters
{
    public class Spearman : Character
    {
        public override string Type => "Spearman";

        public Spearman(ICharacterPrinter characterPrinter, string name) : base(characterPrinter, name, 80, 60, 20)
        {

        }

        public override void Attack(Character target)
        {
            if (target is Infantry)
            {
                Damage *= 2;

                base.Attack(target);

                Damage /= 2;
            }
            else
            {
                base.Attack(target);
            }
        }
    }
}
