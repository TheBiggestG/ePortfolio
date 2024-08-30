namespace RandallDiscordBotUI_Revision.Model
{
    public class GlobalVariable
    {
        public bool IsSessionActive { get; set; } = false;
        public string BaseURLForBotAPI { get; set; } = "http://localhost:5000";

        public LoginModel LoginModel { get; set; }
    }
}
