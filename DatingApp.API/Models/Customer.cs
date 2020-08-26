using System.Text.Json.Serialization;

namespace DatingApp.API.Models
{
    public class Customer
    {
        public int? ID { get; set; }

        public string Name { get; set; }

        public string DOB { get; set; }

        public int GroupID { get; set; }

        [JsonIgnore]
        public ClassifyCustomer Groups { get; set; }
    }
}