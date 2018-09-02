using MNS.Translator.Application.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MNS.Translator.Application.Models
{
    public class HomeViewModel
    {
        [Required(ErrorMessage = "Please supply a text to be translated")]
        public string Text { get; set; }

        [NotMapped]
        public ResponseResult ResponseResult { get; set; }

        public HomeViewModel()
        {
            ResponseResult = new ResponseResult();
        }
    }
}