using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Newtonsoft.Json;

namespace Tenta.Models
{
        public partial class Joke
        {
            [JsonProperty("id")]
            public int ID { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }
        }
}
