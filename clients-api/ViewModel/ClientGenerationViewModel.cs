using System.ComponentModel.DataAnnotations;

namespace clients_api.ViewModel
{
    public class ClientGenerationViewModel
    {
        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }
    }
}