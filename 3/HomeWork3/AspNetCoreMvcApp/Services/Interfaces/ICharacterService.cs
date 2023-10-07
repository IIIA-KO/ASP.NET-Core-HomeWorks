using CharactersClassLibrary.Characters;

namespace AspNetCoreMvcApp.Services.Interfaces
{
    public interface ICharacterService
    {
        public IEnumerable<Character> GetCharacters();

        public void AddCharacter(Character cocktail);

        public void SaveCharactersInfoToTxt(string filePath);
    }
}
