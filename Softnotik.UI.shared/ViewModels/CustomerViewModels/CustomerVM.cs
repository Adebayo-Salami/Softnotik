#nullable disable

using System.Text.Json.Serialization;

namespace Softnotik.UI.Shared.ViewModels.CustomerViewModels
{
    public class CustomerVM
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
    }
}
