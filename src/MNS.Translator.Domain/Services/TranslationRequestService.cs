using MNS.Translator.Domain.Interfaces.Repository;
using MNS.Translator.Domain.Interfaces.Services;
using MNS.Translator.Domain.Models;
using System;

namespace MNS.Translator.Domain.Services
{
    public class TranslationRequestService : ITranslationRequestService
    {
        private readonly ITranslationRequestRepository _translationRequestRepository;

        public TranslationRequestService(ITranslationRequestRepository translationRequestRepository)
        {
            _translationRequestRepository = translationRequestRepository;
        }

        public TranslationRequest Save(TranslationRequest translationRequest)
        {
            translationRequest.IsValid();
            if (!translationRequest.ValidationResult.IsValid)
                return translationRequest;

            try
            {
                _translationRequestRepository.Add(translationRequest);
                _translationRequestRepository.SaveChanges();
            }
            catch (Exception)
            {
                return null;
            }

            return translationRequest;
        }
    }

}


