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
            public string ID { get; set; }

            [JsonProperty("value")]
            public string Value { get; set; }

            public bool IsFavourite { get; set; } = false;
        }
}
