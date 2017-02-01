#region

using db;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

#endregion

namespace server.account
{
    internal class forgotPassword : RequestHandler
    {
        protected override void HandleRequest()
        {
            using (Database db = new Database())
            {

                //Generates a random password
                string password = Database.GenerateRandomString(10);

                //Changes the users password
                var cmd = db.CreateQuery();
                cmd.CommandText = "UPDATE accounts SET password=SHA1(@password) WHERE uuid=@email;";
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", Query["guid"]);


                if (cmd.ExecuteNonQuery() == 1)
                {

                    //Makes the email sending function
                    SmtpClient client = new SmtpClient();
                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new System.Net.NetworkCredential("dieliam6@gmail.com", "pleasedieliam"); //Email credentials



                    //Email information
                    MailMessage mm = new MailMessage("RANDOMEMAILHERE", Query["guid"], "SERVERNAME", "SERVERNAME");
                    mm.Body = "Your new password for SERVERNAME is: " + password + " hopefully you wont forget your password again.";
                    mm.BodyEncoding = UTF8Encoding.UTF8;
                    mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;


                    //Send the actual email
                    client.Send(mm);

                    //Logs the action
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Reset Password Link sent to " + Query["guid"]);
                    Console.ForegroundColor = ConsoleColor.White;

                }
                else
                    using (StreamWriter wtr = new StreamWriter(Context.Response.OutputStream))
                        wtr.Write("<Error>Error.accountNotFound</Error>");
            }
        }
    }
}