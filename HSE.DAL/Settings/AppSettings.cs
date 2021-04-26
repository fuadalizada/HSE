namespace HSE.DAL.Settings
{
    public static class AppSettings
    {
        public static string ConnectionString { get; set; }
        public static string Path { get; set; } = "LDAP://local.ady.az";
        public static string PathAdyExpress = "LDAP://192.168.2.19";
    }
}
