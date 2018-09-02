using MNS.Translator.Domain.Models;

namespace MNS.Translator.Domain.Interfaces.Services
{
    public interface ITranslationRequestService
    {
        TranslationRequest Save(TranslationRequest translationRequest);
    }
}
