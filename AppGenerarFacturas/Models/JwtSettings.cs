﻿namespace AppGenerarFacturas.Models
{
    public class JwtSettings
    {
        public bool ValidateIssuerSigningKey { get; set; }
        public string IssuerSigningKey { get; set; } = string.Empty;

        public bool ValidateIssuer { get; set; } = true;
        public string? ValidIssuer { get; set; }

        public bool ValidateAudience { get; set; }
        public string? ValidAudience { get; set; }

        public bool ValidLifetime { get; set; } = true;
        public bool RequiredExpirationTime { get; set; } 

    }
}
