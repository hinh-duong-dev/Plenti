using System.Net;

namespace Plenti.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ReferralCode { get; set; }
        public virtual Address Address { get; set; }
    }
}
