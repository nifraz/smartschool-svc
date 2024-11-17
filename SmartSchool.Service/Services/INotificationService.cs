using SmartSchool.Schema.Entities;

namespace SmartSchool.Service.Services
{
    public interface INotificationService
    {
        Task SendRegistrationCompletedEmailAsync(User model);
        Task SendVerificationEmailAsync(User model);
        //Task SendVerificationSmsAsync(User model);

        //Task SendSchoolStudentEnrollmentRequestReceivedEmailAsync(SchoolStudentEnrollmentRequest schoolStudentEnrollmentRequest);
        Task SendSchoolStudentEnrollmentRequestApprovedEmailAsync(SchoolStudentEnrollmentRequest schoolStudentEnrollmentRequest, SchoolStudentEnrollment schoolStudentEnrollment, ClassStudentEnrollment classStudentEnrollment);
        Task SendSchoolStudentEnrollmentRequestRejectedEmailAsync(SchoolStudentEnrollmentRequest model);

        //Task SendBookingCancelledSmsAsync(Booking model);
    }
}
