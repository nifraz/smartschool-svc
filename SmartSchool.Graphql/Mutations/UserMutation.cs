namespace SmartSchool.Graphql.Mutations
{
    public class UserMutation
    {
        //public async Task<UserType> RegisterUserAsync(
        //    UserInput input,
        //    [ScopedService] SmartSchoolDbContext context,
        //    [Service] IEmailService emailService)
        //{
        //    // Check if the user already exists
        //    var existingUser = context.Users.FirstOrDefault(u => u.Email == input.Email);
        //    if (existingUser != null)
        //    {
        //        return new RegisterUserPayload
        //        {
        //            Success = false,
        //            Message = "Email already in use."
        //        };
        //    }

        //    // Hash the password
        //    var hashedPassword = BCrypt.Net.BCrypt.HashPassword(input.Password);

        //    // Create new user
        //    var user = new User
        //    {
        //        Email = input.Email,
        //        Password = hashedPassword,
        //        IsEmailVerified = false,
        //        VerificationToken = Guid.NewGuid().ToString(),
        //        TokenExpiration = DateTime.UtcNow.AddHours(24) // Token expires in 24 hours
        //    };

        //    context.Users.Add(user);
        //    await context.SaveChangesAsync();

        //    // Send verification email
        //    await emailService.SendVerificationEmailAsync(user.Email, user.VerificationToken);

        //    return new RegisterUserPayload
        //    {
        //        Success = true,
        //        Message = "Registration successful. Please check your email for verification."
        //    };
        //}

        //public async Task<ResendVerificationEmailPayload> ResendVerificationEmailAsync(
        //ResendVerificationEmailInput input,
        //[ScopedService] ApplicationDbContext context,
        //[Service] IEmailService emailService)
        //{
        //    var user = context.Users.FirstOrDefault(u => u.Email == input.Email);

        //    if (user == null || user.IsEmailVerified)
        //    {
        //        return new ResendVerificationEmailPayload
        //        {
        //            Success = false,
        //            Message = "Invalid email or already verified."
        //        };
        //    }

        //    // Enforce a delay of 15 minutes between resend attempts
        //    if (user.LastVerificationEmailSent.HasValue && (DateTime.UtcNow - user.LastVerificationEmailSent.Value).TotalMinutes < 15)
        //    {
        //        return new ResendVerificationEmailPayload
        //        {
        //            Success = false,
        //            Message = "You must wait at least 15 minutes before resending the email."
        //        };
        //    }

        //    // Update the time the email was sent
        //    user.LastVerificationEmailSent = DateTime.UtcNow;
        //    await context.SaveChangesAsync();

        //    // Send verification email
        //    await emailService.SendVerificationEmailAsync(user.Email, user.VerificationToken);

        //    return new ResendVerificationEmailPayload
        //    {
        //        Success = true,
        //        Message = "Verification email resent successfully."
        //    };
        //}
    }
}
