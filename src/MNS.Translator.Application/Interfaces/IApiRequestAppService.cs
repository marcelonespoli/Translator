using MNS.Translator.Domain.Models;

namespace MNS.Translator.Application.Interfaces
{
    public interface IApiRequestAppService
    {
        TranslationRequest GetTranslation(string text);
    }
}
