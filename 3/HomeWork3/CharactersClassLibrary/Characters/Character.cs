using CharactersClassLibrary.Printers;

namespace CharactersClassLibrary.Characters
{
    public abstract class Character
    {
        public string Name { get; set; }
        public abstract string Type { get; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public int Defense { get; set; }


        public virtual string ShortInfo => $"Name: {Name} | Type: {Type}";
        public virtual string FullInfo => $"Character type: {Type} | Health {Health}hp | Attack damage: {Damage} | Attach Defense {Defense}";

        public ICharacterPrinter CharacterPrinter { get; protected set; }

        public Character(ICharacterPrinter characterPrinter, string name, int health, int damage, int defense)
        {
            CharacterPrinter = characterPrinter;

            Name = name;
            Health = health;
            Damage = damage;
            Defense = defense;
        }

        public virtual void Attack(Character target)
        {
            int damage = Math.Max(Damage - target.Defense, 0);

            Health -= damage;
            target.Health -= damage;

            Console.WriteLine($"{Name} attacks {target.Name} and deals {damage} damage.");
            Console.WriteLine($"{Name}'s health is now {Health}.");
            Console.WriteLine($"{target.Name}'s health is now {target.Health}.");
        }

        public void PrintShortInfoToFile(string filePath)
        {
            if (CharacterPrinter == null)
            {
                throw new NullReferenceException($"Unable to print short info about {this.Type} character since the Character Printer reference is null.");
            }

            CharacterPrinter.PrintShortInfoToFile(filePath, ShortInfo);
        }

        public void PrintFullInfoToFile(string filePath)
        {
            if (CharacterPrinter == null)
            {
                throw new NullReferenceException($"Unable to print full info about {this.Type} character since the Character Printer reference is null.");
            }

            CharacterPrinter.PrintFullInfoToFile(filePath, FullInfo);
        }
    }
}
