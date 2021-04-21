using RestWithASPNET5.Model.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RestWithASPNET5.Data.VO
{
    public class BookVO
    {
        //Muda nome de uma propriedade
        [JsonPropertyName("Identificacao")]
        public long Id { get; set; }

        [JsonPropertyName("Autor")]
        public string Autor { get; set; }

        [JsonPropertyName("Titulo")]
        public string Title { get; set; }

        [JsonPropertyName("Preco")]
        public decimal Price { get; set; }

        // Esconde uma propriedade
        [JsonIgnore]
        public DateTime LaunchDate { get; set; }
    }
}
