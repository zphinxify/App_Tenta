using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tenta.Models
{
    public class JokeSearch
    {
        [JsonProperty("total")]
        public int total;
        
        public List<Joke> result { get; set; }

    }
}
