using Newtonsoft.Json;

namespace e_commerce_API.Data.Entities
{
    public class Client: User
    {
        public string Adress { get; set; }

        public int Dni { get; set; }

        [JsonIgnore]
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
