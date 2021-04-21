using RestWithASPNET5.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestWithASPNET5.Data.VO
{
    public class PersonVO
    {
        //muda nome da propriedade
        [JsonPropertyName("Identificacao")]
        public long Id { get; set; }

        [JsonPropertyName("Nome")]
        public string FirstName { get; set; }

        [JsonPropertyName("Sobrenome")]
        public string LastName { get; set; }

        [JsonPropertyName("Endereco")]
        public string Address { get; set; }

        //esconde uma propriedade
        [JsonIgnore]
        public string Gender { get; set; }
    }
}
