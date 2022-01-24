using MailKit.Net.Smtp;
using MimeKit;

namespace EvaluationSystem.Application.Services.HelpServices
{
    public static class SendEmailService
    {
        private const string linkToPage = "https://auto.loanvantage360.com/Internship/EvanuationSystemNikolina/";
        private const string sendName = "VSG";
        private const string subject = "Evaluation";

        private const string sendEmailAddress = "write your email here...";
        private const string password = "write your password here...";
        private const string host = "write your host here...";
        private const int port = 0;//465

        public static void SendEmail(string formName, string userToEvalName, string participantEmail)
        {

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(sendName, sendEmailAddress));
            message.To.Add(MailboxAddress.Parse(participantEmail));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = @$"You have been assigned attestation {formName} to evaluate {userToEvalName}. Please, sign in {linkToPage} to fill your attestation."
            };

            SmtpClient client = new SmtpClient();
            client.Connect(host, port, true);
            client.Authenticate(sendEmailAddress, password);
            client.Send(message);

        }
    }
}
