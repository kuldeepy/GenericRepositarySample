using System;

namespace BusinessEntities.User
{
    public class TokenEntity
    {
        public int TokenId { get; set; }
        public int UserId { get; set; }
        public string AuthToken { get; set; }
        public DateTime IssuedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}
