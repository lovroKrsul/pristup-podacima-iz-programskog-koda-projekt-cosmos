using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pppk_projekt_Cosmos.Models
{
    public class Osoba
    {
        [JsonProperty(PropertyName="id")]
        public string ID { get; set; }

        [Required]
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [Required] 
        [JsonProperty(PropertyName = "oib")]
        public string OIB { get; set; }
    }
}