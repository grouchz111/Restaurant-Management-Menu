namespace RestaurantManager
{
    public static class CurrentUser
    {
        public static string Username { get; set; }
        public static string Role { get; set; }

        public static bool IsAdmin => Role == "Admin";
        public static bool IsWaiter => Role == "Waiter";
    }
}