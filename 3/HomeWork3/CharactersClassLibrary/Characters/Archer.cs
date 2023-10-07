using CharactersClassLibrary.Printers;

namespace CharactersClassLibrary.Characters
{
    public class Archer : Character
    {
        public override string Type => "Archer";

        public Archer(ICharacterPrinter characterPrinter, string name) : base(characterPrinter, name, 60, 40, 10)
        {

        }

        public override void Attack(Character target)
        {
            if (target is Spearman)
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
