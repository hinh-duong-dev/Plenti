namespace Plenti.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string FullAddress => $"{StreetAddress}, {Suburb}, {State}";

    }
}
