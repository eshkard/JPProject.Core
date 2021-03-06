using System.ComponentModel.DataAnnotations;

namespace JPProject.Admin.Application.ViewModels.ClientsViewModels
{
    public class RemoveClientSecretViewModel
    {

        public RemoveClientSecretViewModel(string clientId, int id)
        {
            ClientId = clientId;
            Id = id;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string ClientId { get; set; }
    }
}
