using MNS.Translator.Domain.Interfaces.Repository;
using MNS.Translator.Domain.Models;
using MNS.Translator.Infra.Data.Context;
using System.Collections.Generic;

namespace MNS.Translator.Infra.Data.Repository
{
    public class TranslationRequestRepository : Repository<TranslationRequest>, ITranslationRequestRepository
    {
        public TranslationRequestRepository(TranslatorContext context) : base(context) { }

        public IEnumerable<TranslationRequest> GetAllFail()
        {
            return Search(c => c.Success == false);
        }

        public IEnumerable<TranslationRequest> GetAllSuccess()
        {
            return Search(c => c.Success == true);
        }
    }
}
