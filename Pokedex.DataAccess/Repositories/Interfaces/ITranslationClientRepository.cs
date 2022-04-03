using System.Threading.Tasks;

namespace Pokedex.DataAccess.Repositories.Interfaces
{
    public interface ITranslationClientRepository
    {
        Task<string> GetTranslatedDescription(string description, bool isYodaTranslationRequired);
    }
}
