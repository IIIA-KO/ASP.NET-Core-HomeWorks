using AspNetCoreMvcApp.Services.Interfaces;
using CharactersClassLibrary.Characters;
using CharactersClassLibrary.Printers;
using CocktailClassLibrary.Cocktails;

namespace AspNetCoreMvcApp.Services.Implementations
{
    public class CharacterService : ICharacterService
    {
        private ICollection<Character> Characters { get; set; }
        public ICharacterPrinter _printer;

        public CharacterService(ICharacterPrinter printer)
        {
            Characters = new List<Character>();
            this._printer = printer;
        }

        public IEnumerable<Character> GetCharacters()
        {
            return Characters ?? new List<Character>();
        }

        public void AddCharacter(Character character)
        {
            if (Characters == null)
            {
                throw new NullReferenceException("Unable to add character due to null reference in Character Service's collection.");
            }
            Characters.Add(character);
        }

        public void SaveCharactersInfoToTxt(string filePath)
        {
            if (Characters == null)
            {
                throw new NullReferenceException("Unable to output info about characters due to null reference in Character Service's collection.");
            }

            foreach (Character character in Characters)
            {
                if (character != null)
                {
                    character.PrintShortInfoToFile(filePath);
                    character.PrintFullInfoToFile(filePath);
                }
            }
        }
    }
}
