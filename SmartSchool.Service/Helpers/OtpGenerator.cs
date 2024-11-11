using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartSchool.Service.Helpers
{
    public static class OtpGenerator
    {
        public static string GenerateOtp()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[4];
                rng.GetBytes(bytes);

                // Convert bytes to a positive integer
                int generatedNumber = Math.Abs(BitConverter.ToInt32(bytes, 0));

                // Ensure it's a 6-digit number
                int otp = generatedNumber % 1000000;

                // Pad with leading zeros if necessary
                return otp.ToString("D6");
            }
        }
    }
}
