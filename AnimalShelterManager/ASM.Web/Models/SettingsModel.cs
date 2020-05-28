using System.ComponentModel.DataAnnotations;

namespace ASM.Web.Models
{
    public class SettingsModel 
    {
        [Required] public string Title { get; set; }

        public string Message { get; set; }
        public string MessageType { get; set; }

        #region Address

        [Required] public string Line1 { get; set; }
        public string Line2 { get; set; }
        [Required] public string PostCode { get; set; }
        [Required] public string City { get; set; }
        public string Country { get; set; }

        #endregion

        #region Contact Details

        [Required, EmailAddress] public string Email { get; set; }
        [Required, Phone] public string Phone { get; set; }
        [Phone] public string Mobile { get; set; }

        #endregion
    }
}
