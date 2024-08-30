using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using SQLiteInserts;
using SQLiteInserts.Models;

namespace RandalBot
{

    class Program
    {
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;
        public string[] badWordList = { "badword1", "badword2" }; //PlaceholderBadwordList
        public string[] TempEventLog; //Placeholder Eventlogger
        private const ulong MutedRoleId = 1196362522849181827; //Used for muting people
        public int[] warnlist; //Place Databank ID here

        static void Main(string[] args)
            => new Program().RunBotAsync(args).GetAwaiter().GetResult();

        public async Task RunBotAsync(string[] args)
        {
            var config = new DiscordSocketConfig()
            {
                GatewayIntents = GatewayIntents.All
            };
            _client = new DiscordSocketClient(config);
            _commands = new CommandService();

            _client.Log += Log;

            if (File.Exists("./BadWordJSON.json"))
            {
                var content = File.ReadAllText("./BadWordJSON.json");

                string[] temp = System.Text.Json.JsonSerializer.Deserialize<string[]>(content);

                badWordList = temp;
            }

            _client.MessageReceived += MessageFilter;



            await _client.LoginAsync(TokenType.Bot, "MTE4NjIwNzIxOTI4NTUwNDAyMQ.G-qFtm.v1q73RUPCIYmbtlCT3ent3PwjKVSE80mmNdTvs");
            await _client.StartAsync();

            _client.Ready += OnReady;       
            await RegisterCommandsAsync();
			//await CreateHostBuilder(_client).Build().RunAsync();

			//API
			var builder = WebApplication.CreateBuilder(args);
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("AllowAllOrigins", builder =>
				{
					builder.AllowAnyOrigin()
						   .AllowAnyHeader()
						   .AllowAnyMethod();
				});
			});

			builder.Services.AddControllers()
				   .AddJsonOptions(options =>
				   {
					   options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
					   options.JsonSerializerOptions.WriteIndented = true; // Optional, for readable JSON
				   });

			builder.Services.AddSingleton<DiscordSocketClient>(_client);
			var app = builder.Build();
			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseCors("AllowAllOrigins"); // Apply the CORS policy here
			app.UseAuthorization();
			app.MapControllers();
			app.Run();

			//_client.Ready += OnReady;

			await Task.Delay(-1);
        }
        private Task Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }
        public async Task RegisterCommandsAsync()
        {
            _client.Log += Log;

            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }
        private async Task OnReady()
        {
            Console.WriteLine("Bot is connected!");
            var channel = _client.GetChannel(1186215061170176073) as IMessageChannel;
            //await channel.SendMessageAsync("Bot is connected!");

            Console.WriteLine("AAA" + _client.GetGuild(1186215061170176070));

            foreach (SocketGuild Guild in _client.Guilds)
            {
                List < DiscordServer > discordServersDB = DBController.Instance.ReadDiscordServers();
                List<DiscordUser> discordUsersDB = DBController.Instance.ReadDiscordUsers();
                List<UserIsInServer> discordUsersInServerDB = DBController.Instance.ReadUserIsInServer();

                if (discordServersDB.Find(e => e._internalId == Guild.Id) == null) {
                    DBController.Instance.InsertDiscordServer(Guild.Id, Guild.Name);
                    discordServersDB = DBController.Instance.ReadDiscordServers();
                }
                foreach (SocketGuildUser user in _client.GetGuild(Guild.Id). Users)
                {
                    Console.WriteLine(user.Username);
                    DiscordUser? contextuser = discordUsersDB.Find(e => e._internalId == user.Id);
                    if (contextuser == null)
                    {
                        DBController.Instance.InsertDiscordUser(user.Id, user.Username, 0);
                        SQLiteInserts.DBController.Instance.InsertUserIsInServer(user.Id, Guild.Id);
                    }
                    else if (discordUsersInServerDB.Find(e => e.FkDiscordUserId == contextuser._id && e.FkServerId == discordServersDB.Find(e => e._internalId == Guild.Id)._id) == null)
                    {
                        SQLiteInserts.DBController.Instance.InsertUserIsInServer(user.Id, Guild.Id);
                    }
                }
            }
        }
        private async Task MessageFilter(SocketMessage message)
        {
            try
            {
                Console.WriteLine(message);
                if (message.Author.IsBot) return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + " Error with message filter");
            }
        }
        /*private async void WarnSystem(int warNum, int DatabankId)
        {
            switch ()
            {
                case 3: Console.WriteLine();
                case 4: Console.WriteLine();
            }
        }*/
        private async Task BotResponseCleanup(IUserMessage botResponse)
        {
            try
            {
                var channel = botResponse.Channel as IMessageChannel;
                var message = await channel.GetMessageAsync(botResponse.Id);

                if (message != null)
                {
                    await Task.Delay(5000);

                    await message.DeleteAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting bot response: {ex.Message}");
            }
        }
        //public static IHostBuilder CreateHostBuilder(DiscordSocketClient discordSocketClient, string[] args = null) =>
        //Host.CreateDefaultBuilder(args)
        //    .ConfigureWebHostDefaults(webBuilder =>
        //    {
        //        webBuilder.UseStartup<Startup>().ConfigureServices(services =>
        //        {
        //            services.AddSingleton(discordSocketClient);
        //        });
        //    });
        }
    }
