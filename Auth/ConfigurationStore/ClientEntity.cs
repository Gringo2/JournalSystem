using IdentityServer4.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auth.ConfigurationStore
{
    public class ClientEntity
    {
        public string ClientData { get; set; }

        [Key]
        public string ClientId { get; set; }

        [NotMapped]
        public Client Client { get; set; }
        //Saves Client
        public void AddDataToEntity()
        {
            ClientData = JsonConvert.SerializeObject(Client);
            ClientId = Client.ClientId;
        }
        //gets client
        public void MapDataFromEntity()
        {
            Client = JsonConvert.DeserializeObject<Client>(ClientData);
            ClientId = Client.ClientId;
        }
    }
}
