using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using System.Text;
using Newtonsoft.Json;
using SmartSchool.Utility.Helpers;
using SmartSchool.Schema.Entities;
using SmartSchool.Service.Models.Settings;

namespace SmartSchool.Service.Services
{
    public class NotificationService : INotificationService
    {
        private readonly SmtpSettings smtpSettings;
        private readonly SmsSettings smsSettings;
        private readonly HttpClient httpClient;

        public NotificationService(
            IOptions<SmtpSettings> smtpSettings,
            IOptions<SmsSettings> smsSettings,
            HttpClient httpClient
            )
        {
            this.smtpSettings = smtpSettings.Value;
            this.smsSettings = smsSettings.Value;
            this.httpClient = httpClient;

            httpClient.DefaultRequestHeaders.Add("x-api-key", this.smsSettings.ApiKey);
        }

        public async Task SendEmailAsync(string toName, string toEmail, string subject, string htmlContent)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(smtpSettings.SenderName, smtpSettings.FromEmail));
            message.To.Add(new MailboxAddress(toName, toEmail));
            message.Subject = subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = htmlContent
            };

            message.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            client.ServerCertificateValidationCallback = (s, c, h, e) => true; // Disable SSL validation
            await client.ConnectAsync(smtpSettings.Server, smtpSettings.Port, smtpSettings.EnableSsl);
            await client.AuthenticateAsync(smtpSettings.Username, smtpSettings.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }

        public async Task<string> SendSmsAsync(string toPhoneNumber, string messageContent)
        {
            var messagePayload = new
            {
                from = smsSettings.FromPhoneNumber,
                to = toPhoneNumber,
                content = messageContent
            };

            var jsonPayload = JsonConvert.SerializeObject(messagePayload);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://api.httpsms.com/v1/messages/send", httpContent);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task SendRegistrationCompletedEmailAsync(User model)
        {
            if (!string.IsNullOrWhiteSpace(model.Person.Email))
            {
                var emailBody = TemplateGenerator.BuildRegistrationCompletedEmailBody(model);
                await SendEmailAsync(model.Person.FullName, model.Person.Email, "Welcome to SmartSchool Service!", emailBody);
                await SendVerificationEmailAsync(model);
            }
        }

        public async Task SendVerificationEmailAsync(User model)
        {
            if (!string.IsNullOrWhiteSpace(model.Person.Email))
            {
                var emailBody = TemplateGenerator.BuildEmailVerificationBody(model);
                await SendEmailAsync(model.Person.FullName, model.Person.Email, "SmartSchool Login Email Verification!", emailBody);
            }
        }

        public async Task SendSchoolStudentEnrollmentRequestApprovedEmailAsync(SchoolStudentEnrollmentRequest schoolStudentEnrollmentRequest, SchoolStudentEnrollment schoolStudentEnrollment, ClassStudentEnrollment classStudentEnrollment)
        {
            if (!string.IsNullOrWhiteSpace(schoolStudentEnrollmentRequest.Person.Email))
            {
                var userEmailBody = TemplateGenerator.BuildSchoolStudentEnrollmentRequestApprovedUserEmailBody(schoolStudentEnrollmentRequest, schoolStudentEnrollment, classStudentEnrollment);
                await SendEmailAsync(schoolStudentEnrollmentRequest.Person.FullName, schoolStudentEnrollmentRequest.Person.Email, "School Student Enrollment Request Approved", userEmailBody);
            }
        }

        public async Task SendSchoolStudentEnrollmentRequestRejectedEmailAsync(SchoolStudentEnrollmentRequest model)
        {
            if (!string.IsNullOrWhiteSpace(model.Person.Email))
            {
                var userEmailBody = TemplateGenerator.BuildSchoolStudentEnrollmentRequestRejectedUserEmailBody(model);
                await SendEmailAsync(model.Person.FullName, model.Person.Email, "School Student Enrollment Request Rejected - Smart School", userEmailBody);
            }
        }

        //public async Task SendBookingCancelledSmsAsync(Booking model)
        //{
        //    if (!string.IsNullOrWhiteSpace(model.User.MobileNo))
        //    {
        //        var userSmsBody = TemplateGenerator.BuildBookingCancelledUserSms(model);
        //        await SendSmsAsync(model.User.MobileNo, userSmsBody);
        //    }

        //    if (!string.IsNullOrWhiteSpace(model.Vehicle.Driver.MobileNo))
        //    {
        //        var driverSmsBody = TemplateGenerator.BuildBookingCancelledDriverSms(model);
        //        await SendSmsAsync(model.Vehicle.Driver.MobileNo, driverSmsBody);
        //    }
        //}
    }
}
