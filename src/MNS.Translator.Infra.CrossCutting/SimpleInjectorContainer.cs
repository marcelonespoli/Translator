using MNS.Translator.Application.Interfaces;
using MNS.Translator.Application.Services;
using MNS.Translator.Domain.Interfaces.Repository;
using MNS.Translator.Domain.Interfaces.Services;
using MNS.Translator.Domain.Services;
using MNS.Translator.Infra.Data.Context;
using MNS.Translator.Infra.Data.Repository;
using SimpleInjector;

namespace MNS.Translator.Infra.CrossCutting
{
    public class SimpleInjectorContainer
    {
        public static void Register(Container container)
        {
            // APP
            container.Register<ITranslationRequestAppService, TranslationRequestAppService>(Lifestyle.Scoped);
            container.Register<IApiRequestAppService, ApiRequestAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<ITranslationRequestService, TranslationRequestService>(Lifestyle.Scoped);

            // Infra.Data
            container.Register<ITranslationRequestRepository, TranslationRequestRepository>(Lifestyle.Scoped);
            container.Register<TranslatorContext>(Lifestyle.Scoped);
        }
    }
}
