namespace CustomIdentityApp.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public int Weight { get; set; }

        public string CargoType { get; set; }

        public string Date { get; set; }
    }
}
