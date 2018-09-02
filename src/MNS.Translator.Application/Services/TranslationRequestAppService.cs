using MNS.Translator.Application.Interfaces;
using MNS.Translator.Application.ValueObjects;
using MNS.Translator.Domain.Interfaces.Services;

namespace MNS.Translator.Application.Services
{
    public class TranslationRequestAppService : ITranslationRequestAppService
    {
        private readonly ITranslationRequestService _translationRequestService;
        private readonly IApiRequestAppService _apiRequestAppService;

        public TranslationRequestAppService(ITranslationRequestService translationRequestService, IApiRequestAppService apiRequestAppService)
        {
            _translationRequestService = translationRequestService;
            _apiRequestAppService = apiRequestAppService;
        }
               

        public ResponseResult GetTranslation(string text)
        {
            var responseResult = new ResponseResult();

            var translationRequest = _apiRequestAppService.GetTranslation(text);
            if (translationRequest == null)
            {
                responseResult.Message = "Service not available, please try again.";
                return responseResult;
            }                

            translationRequest = _translationRequestService.Save(translationRequest);
            if (translationRequest == null || !translationRequest.ValidationResult.IsValid)
            {
                responseResult.Message = "Occurred an error to process the request.";
                return responseResult;
            }                

            if (translationRequest.Success)
            {
                responseResult.Success = true;
                responseResult.Translation = translationRequest.Translation;
            }
            else
            {
                responseResult.Success = false;
                responseResult.Message = translationRequest.ErrorMessage;
            }
            return responseResult;
        }

    }
}
