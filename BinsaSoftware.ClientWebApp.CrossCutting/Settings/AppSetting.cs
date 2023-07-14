namespace BinsaSoftware.ClientWebApp.CrossCutting.Settings
{
    public class AppSetting
    {
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string DataSource { get; set; }
        public string Catalog { get; set; }
    }
}
