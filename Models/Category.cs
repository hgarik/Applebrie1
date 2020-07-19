using System.Collections.Generic;
using System.Text.Json.Serialization;
using WebApi.Data;

namespace WebApi.Models
{
    public class Category : IBaseEntity
    {
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<User> User { get; set; }
        public int Id { get; set; }
    }
}