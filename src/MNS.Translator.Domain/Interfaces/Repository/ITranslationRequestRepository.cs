using MNS.Translator.Domain.Models;
using System.Collections.Generic;

namespace MNS.Translator.Domain.Interfaces.Repository
{
    public interface ITranslationRequestRepository : ITranslationRequestRepository<TranslationRequest>
    {
        IEnumerable<TranslationRequest> GetAllSuccess();
        IEnumerable<TranslationRequest> GetAllFail();
    }
}
