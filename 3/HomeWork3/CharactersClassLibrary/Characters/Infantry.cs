using CharactersClassLibrary.Printers;

namespace CharactersClassLibrary.Characters
{
    public class Infantry : Character
    {
        public override string Type => "Infantry";

        public Infantry(ICharacterPrinter printer, string name) : base(printer, name, 100, 50, 30)
        {

        }

        public override void Attack(Character target)
        {
            if (target is Archer)
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
