using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.SlashCommands;
using inscription.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace inscription
{
    public static class ButtonInteractions
    {
        public static async Task HandleInteraction(ComponentInteractionCreateEventArgs componentInteractionCreateEventArgs)
        {
            Regex regex = new(@"<@!*&*[0-9]+>");
            var mentions = regex.Matches(componentInteractionCreateEventArgs.Message.Content).OrderBy(m => m.Index).Select(m => m.Value).ToList();

            string message = componentInteractionCreateEventArgs.Message.Content.Split("\n").First();

            switch (componentInteractionCreateEventArgs.Id)
            {
                case "subscribe":
                    if (!mentions.Contains(componentInteractionCreateEventArgs.User.Mention))
                    {
                        mentions.Add(componentInteractionCreateEventArgs.User.Mention);
                    }
                    break;

                case "unsubscribe":
                    mentions.RemoveAll(m => m == componentInteractionCreateEventArgs.User.Mention);
                    break;
            }

            var content = new DiscordInteractionResponseBuilder()
                .WithContent(message + "\n" + string.Join("\n", NumerateUsers(mentions)))
                .AddComponents(DiscordMessageBuilderHelper.GetInscriptionButtons());

            await componentInteractionCreateEventArgs.Interaction.CreateResponseAsync(InteractionResponseType.UpdateMessage, content);
        }

        private static List<string> NumerateUsers(List<string> mentions)
        {
            mentions = mentions.Select((m, index) => $"{++index}. {m}").ToList();

            return mentions;
        }
    }
}
