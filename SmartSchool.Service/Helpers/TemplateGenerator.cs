using SmartSchool.Schema;
using SmartSchool.Schema.Entities;
using System.Globalization;

namespace SmartSchool.Utility.Helpers
{
    public static class TemplateGenerator
    {
        public static string FromEmail { get; set; }
        public static string FromPhoneNumber { get; set; }
        public static int Year { get; set; } = DateTime.Now.Year;

        public static CultureInfo cultureInfo = new("si-LK")
        {
            NumberFormat = new NumberFormatInfo
            {
                CurrencySymbol = "LKR",
            },
        }; // Set culture to Sri Lanka

        public static string BuildRegistrationCompletedEmailBody(User model)
        {
            return $@"
            <html>
                <body style='font-family: Arial, sans-serif; font-size: 14px; color: #333; background-color: #f4f4f4; padding: 20px;'>
                    <div style='max-width: 600px; margin: 0 auto; background-color: #fff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1);'>
                        <header style='text-align: center; margin-bottom: 30px;'>
                            <h2 style='color: #2e6c80;'>Welcome to SmartSchool Service, {model.Person.FullName}!</h2>
                        </header>

                        <p style='line-height: 1.6;'>
                            Thank you for registering with SmartSchool. We’re excited to have you on board!
                        </p>
                
                        <p style='line-height: 1.6;'>
                            <strong>Your Email:</strong> {model.Person.Email}<br />
                            <strong>Verification Code:</strong> {model.EmailVerificationOtp}<br />
                            <strong>Your Mobile No:</strong> {model.Person.MobileNo}<br />
                        </p>

                        <div style='margin-top: 30px; padding: 15px; background-color: #2e6c80; color: white; text-align: center; border-radius: 8px;'>
                            <p style='margin: 0;'>
                                <a href='http://localhost:4200/auth/verify-email?email={model.Person.Email}&token={model.EmailVerificationToken}' style='color: white; text-decoration: underline;'>Click Here to Verify Your Email</a>!
                            </p>
                        </div>

                        <p style='margin-top: 30px;'>
                            If you have any questions, feel free to <a href='mailto:{FromEmail}' style='color: #2e6c80;'>contact us</a>.
                        </p>
                        <hr style='border-top: 1px solid #ddd; margin-top: 30px;' />
                        <footer style='font-size: 12px; color: #777; text-align: center;'>&copy; {Year} SmartSchool Service. All rights reserved.</footer>
                    </div>
                </body>
            </html>
            ";
        }

        public static string BuildSchoolStudentEnrollmentRequestApprovedUserEmailBody(SchoolStudentEnrollmentRequest schoolStudentEnrollmentRequest, SchoolStudentEnrollment schoolStudentEnrollment, ClassStudentEnrollment classStudentEnrollment)
        {
            return $@"
            <html>
                <body style='font-family: Arial, sans-serif; font-size: 14px; color: #333; background-color: #f4f4f4; padding: 20px;'>
                    <div style='max-width: 600px; margin: 0 auto; background-color: #fff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1);'>
                        <header style='text-align: center; margin-bottom: 30px;'>
                            <h2 style='color: #2e6c80;'>Congratulations! Your School Student Enrollment Request has been approved by the School.</h2>
                        </header>

                        <p style='line-height: 1.6;'><strong>Booking Details:</strong><br />
                            <strong>Full Name:</strong> {schoolStudentEnrollmentRequest.Person.FullName}
                            <strong>School Name:</strong> {schoolStudentEnrollment.School.Name}<br />
                            <strong>Class:</strong> {classStudentEnrollment.Class.ToString()}<br />
                            <strong>Academic Year:</strong> {classStudentEnrollment.AcademicYear}<br />
                        </p>

                        <p style='line-height: 1.6;'>You will receive further updates on your Enrollment. Stay tuned!</p>

                        <p style='margin-top: 30px;'>If you have any questions, feel free to <a href='mailto:{FromEmail}' style='color: #2e6c80;'>contact us</a>.</p>

                        <hr style='border-top: 1px solid #ddd; margin-top: 30px;' />

                        <footer style='font-size: 12px; color: #777; text-align: center;'>&copy; {Year} SmartSchool Service. All rights reserved.</footer>
                    </div>
                </body>
            </html>";
        }

        public static string BuildSchoolStudentEnrollmentRequestRejectedUserEmailBody(SchoolStudentEnrollmentRequest schoolStudentEnrollmentRequest)
        {
            return $@"
            <html>
                <body style='font-family: Arial, sans-serif; font-size: 14px; color: #333; background-color: #f4f4f4; padding: 20px;'>
                    <div style='max-width: 600px; margin: 0 auto; background-color: #fff; padding: 20px; border-radius: 8px; box-shadow: 0 0 10px rgba(0,0,0,0.1);'>
                        <header style='text-align: center; margin-bottom: 30px;'>
                            <h2 style='color: #2e6c80;'>Sorry! Your School Student Enrollment Request has been rejected by the School.</h2>
                        </header>

                        <p style='line-height: 1.6;'><strong>Booking Details:</strong><br />
                            <strong>Full Name:</strong> {schoolStudentEnrollmentRequest.Person.FullName}
                            <strong>School Name:</strong> {schoolStudentEnrollmentRequest.School.Name}<br />
                            <strong>Grade:</strong> {schoolStudentEnrollmentRequest.Grade}<br />
                            <strong>Academic Year:</strong> {schoolStudentEnrollmentRequest.AcademicYear}<br />
                            <strong>Reason:</strong> {schoolStudentEnrollmentRequest.Reason}<br />
                        </p>

                        <p style='margin-top: 30px;'>If you have any questions, feel free to <a href='mailto:{FromEmail}' style='color: #2e6c80;'>contact us</a>.</p>

                        <hr style='border-top: 1px solid #ddd; margin-top: 30px;' />

                        <footer style='font-size: 12px; color: #777; text-align: center;'>&copy; {Year} SmartSchool Service. All rights reserved.</footer>
                    </div>
                </body>
            </html>";
        }

        //public static string BuildBookingCancelledDriverSms(Booking model)
        //{
        //    return $"The booking has been cancelled. Passenger: {model.User.Name}. Booking ID: {model.Id}. We're sorry for the inconvenience. Please standby for new bookings.";
        //}

    }
}
