using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Pokedex.DataAccess.Models
{
  public  class PokemonDescription
    {
        [JsonProperty("flavor_text")]
        public string Description { get; set; }
        public Language Language { get; set; }
    }
}
