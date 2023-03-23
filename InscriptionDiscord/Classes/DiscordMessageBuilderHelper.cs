using DSharpPlus;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inscription.Classes
{
    public class DiscordMessageBuilderHelper
    {
        public static DiscordInteractionResponseBuilder BuildDefaultInscriptionResponse(string message)
        {
            // Buttons
            List<DiscordComponent> discordComponents = GetInscriptionButtons();

            DiscordInteractionResponseBuilder content = new DiscordInteractionResponseBuilder()
                .WithContent(message)
                .AddComponents(discordComponents);

            return content;
        }

        public static List<DiscordComponent> GetInscriptionButtons()
        {
            var result = new List<DiscordComponent> 
            {
                new DiscordButtonComponent(ButtonStyle.Primary, "subscribe", "S'inscrire"),
                new DiscordButtonComponent(ButtonStyle.Danger, "unsubscribe", "Se désinscrire"),
            };

            return result;
        }
    }
}
