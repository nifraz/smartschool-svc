using SmartSchool.Schema.Entities;

namespace SmartSchool.Service.Models
{
    public class AuthenticateResponse(User user, JwtData jwtData) : JwtData(jwtData.Token, jwtData.Expires)
    {
        public long UserId { get; set; } = user.Id;
        public string FullName { get; set; } = user.Person.FullName;
        public string Email { get; set; } = user.Person.Email!;
        public string MobileNo { get; set; } = user.Person.MobileNo!;
        public bool IsEmailVerified { get; set; } = user.IsEmailVerified;
        public bool IsMobileNoVerified { get; set; } = user.IsMobileNoVerified;
    }
}
