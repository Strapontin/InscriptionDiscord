using DSharpPlus;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.SlashCommands;
using inscription;
using inscription.Commands;
using System.Configuration;

var discord = new DiscordClient(new DiscordConfiguration()
{
    Token = ConfigurationManager.AppSettings["DISCORD_KEY_INSCRIPTION"],
    TokenType = TokenType.Bot,
    Intents = DiscordIntents.AllUnprivileged,
    MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,
});

var slash = discord.UseSlashCommands();
slash.RegisterCommands<EmptyGlobalCommandToAvoidFamousDuplicateSlashCommandsBug>();
slash.RegisterCommands<SlashCommands>();

discord.UseInteractivity(new InteractivityConfiguration()
{
    PollBehaviour = DSharpPlus.Interactivity.Enums.PollBehaviour.KeepEmojis,
});

// On button clicked
discord.ComponentInteractionCreated += async (discordClient, componentInteractionCreateEventArgs) =>
{
    await ButtonInteractions.HandleInteraction(componentInteractionCreateEventArgs);
};

await discord.ConnectAsync();

await Task.Delay(-1);
