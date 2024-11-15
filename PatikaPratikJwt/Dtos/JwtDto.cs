﻿using PatikaPratikJwt.Entities;

namespace PatikaPratikJwt.Dtos
{
    public class JwtDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int ExpireMinutes { get; set; }
        public UserType UserType { get; set; }
    }
}
