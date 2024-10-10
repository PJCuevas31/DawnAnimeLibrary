using System;
using MailKit.Net.Smtp;
using MimeKit;

namespace Dawn.API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create the email message
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("FromMyNotes", "do-not-reply@frommynotes.com"));
            message.To.Add(new MailboxAddress("User", "user@example.com"));
            message.Subject = "Thanks for Subscribing!";

            message.Body = new TextPart("html")
            {
                Text = "<h1>Hi, User!</h1>" +
                       "<p>Thank you for subscribing to frommynotes newsletter.</p>" +
                       "<p><strong>Welcome!</strong></p>"
            };

            // Send the email using SMTP client
            using (var client = new SmtpClient())
            {
                try
                {
                    // Connect to the Mailtrap SMTP server (using MailKit)
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    // Authenticate using the credentials from Mailtrap
                    client.Authenticate("602b78bbb02aaf", "3152a8086e96b0");

                    // Send the email
                    client.Send(message);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    // Disconnect the SMTP client
                    client.Disconnect(true);
                }
            }
        }
    }
}
