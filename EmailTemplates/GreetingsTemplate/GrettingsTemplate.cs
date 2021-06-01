using SESClient.EmailClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SESClient.EmailTemplates.GreetingsTemplate
{
    public class GreetingsTemplate : IEmailTemplate
    {
        [JsonIgnore]
        public string TemplateName => "GreetingsTemplate";

        public string Name { get; set; }
        public string FavoriteAnimal { get; set; }

        public string PrepareTemplateData()
        {
            return JsonSerializer.Serialize(
                this,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }
    }
}
