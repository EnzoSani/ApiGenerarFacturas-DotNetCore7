namespace AppGenerarFacturas.DTOS
{
    public class UserDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string PasswordHas { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public DateTime TokenCreated { get; set; }
        public DateTime TokenExpires { get; set; }
    }
}
