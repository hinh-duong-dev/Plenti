namespace Plenti.Model
{
    public class User
    {
        public string Name { get; set; }
        public string ReferralCode { get; set; }
        public virtual Address Address { get; set; }
    }
}
