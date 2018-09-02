using MNS.Translator.Application.ValueObjects;

namespace MNS.Translator.Application.Interfaces
{
    public interface ITranslationRequestAppService
    {
        ResponseResult GetTranslation(string text);
    }
}
