using System.ComponentModel.DataAnnotations;

namespace ASM.Web.Models
{
    public class BaseViewModel
    {
        [Required] public string Title { get; set; }
        public string Message { get; set; }
        public string MessageType { get; set; }
    }
}
