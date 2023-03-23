using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using inscription.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace inscription.Commands
{
    public class SlashCommands : ApplicationCommandModule
    {
        //public override async Task<bool> BeforeSlashExecutionAsync(InteractionContext ctx)
        //{
        //    bool result = FactsManager.CanExecuteSlashCommand(ctx);

        //    if (!result)
        //    {
        //        await ctx.CreateResponseAsync("Ce channel n'est pas autorisé pour le bot !", true);
        //    }

        //    return result;
        //}


        [SlashCommand("inscription", "Crée un message d'inscriptions")]
        public static async Task FactCommand(InteractionContext ctx)
        {
            var content = DiscordMessageBuilderHelper.BuildDefaultInscriptionResponse();

            await ctx.CreateResponseAsync(content);
        }
    }
}
