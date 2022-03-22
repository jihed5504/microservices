﻿using Nxm.Conan.Users.Core.Attributes.V1;

namespace Nxm.Conan.Users.Core.Entities.V1
{
    [BsonCollection("RefreshTokens")]
    public class RefreshToken : Document
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsExpired => DateTime.UtcNow >= Expires;
        public string CreatedByIp { get; set; }
        public DateTime? Revoked { get; set; }
        public string RevokedByIp { get; set; }
        public string ReplacedByToken { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}
