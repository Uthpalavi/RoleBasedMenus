using System;

namespace EFWebApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Enabled { get; set; }
        public int AccountNonExpired { get; set; }
        public int CredentialsNonExpired { get; set; }
        public int AccountNonLocked { get; set; }
    }
}
