using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace PORTAL.Custom
{
    /// <summary>
    /// EMail is the general purpose SMTP Mail Engine object that is part of the System.Net.Mail namespace.  This is the same as the code inside of PIPES.
    /// </summary>
    public class EMail
    {
        /// <summary>
        /// Send Mail is the SMTP Mail Client for interface with email systems.
        /// </summary>
        /// <param name="emailSubject">The subject of the email</param>
        /// <param name="emailBody">The body of the email</param>
        /// <param name="toEmailList">the TO: list of email recipients</param>
        /// <param name="ccEmailList">the CC: list of email recipients</param>
        /// <param name="bccEmailList">the BCC: list of email recipients</param>
        /// <param name="fromEmail">the From: list of email senders</param>
        /// <param name="attachments">one or more attachment files.</param>
        /// <returns>bool true if sent, or false if not.</returns>
        public bool SendEMail(string emailSubject, string emailBody, string[] toEmailList, string[] ccEmailList = null, string[] bccEmailList = null, string fromEmail = null, Dictionary<string, Byte[]> attachments = null)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;

            if (fromEmail != null && fromEmail.ToLower().Trim().Contains(".com"))
                mailMessage.From = new MailAddress(fromEmail);
            else
                mailMessage.From = new MailAddress("PIPES-NOREPLY@cleanwaterteam.com");

            bool isRecipientExist = false;
            if (toEmailList != null && toEmailList.Count() > 0)
            {
                foreach (var toEmail in toEmailList)
                {
                    // Check to make sure this is a valid email address before we add it to our list
                    try
                    {
                        if (toEmail != null && toEmail != "")
                        {
                            MailAddress m = new MailAddress(toEmail);
                            mailMessage.To.Add(toEmail);
                        }
                    }
                    catch (Exception )
                    {
                        // That email address is not valid, we would log here if we could
                        Debug.WriteLine("Encountered a bad email address: " + toEmail);
                    }
                }
                isRecipientExist = true;
            }
         
            if (ccEmailList != null && ccEmailList.Count() > 0)
            {
                foreach (var ccEmail in ccEmailList)
                {
                    // Check to make sure this is a valid email address before we add it to our list
                    try
                    {
                        if (ccEmail != null && ccEmail != "")
                        {
                            MailAddress m = new MailAddress(ccEmail);
                            mailMessage.CC.Add(ccEmail);
                        }
                    }
                    catch (Exception )
                    {
                        // That email address is not valid, we would log here if we could
                        Debug.WriteLine("Encountered a bad email address: " + ccEmail);
                    }
                }
                isRecipientExist = true;
            }

            if (bccEmailList != null && bccEmailList.Count() > 0)
            {
                foreach (var bccEmail in bccEmailList)
                {
                    // Check to make sure this is a valid email address before we add it to our list
                    try
                    {
                        if (bccEmail != null && bccEmail != "")
                        {
                            MailAddress m = new MailAddress(bccEmail);
                            mailMessage.Bcc.Add(bccEmail);
                        }
                    }
                    catch (Exception )
                    {
                        // That email address is not valid, we would log here if we could
                        Debug.WriteLine("Encountered a bad email address: " + bccEmail);
                    }
                }
                isRecipientExist = true;
            }
            if(!isRecipientExist)
            {
                return false;
            }
            if (emailSubject != null && emailSubject.Trim() != "")
                mailMessage.Subject = emailSubject;
            else
                mailMessage.Subject = "EPIMS";

            if (emailBody != null && emailBody.Trim() != "")
                mailMessage.Body = emailBody;
            else
                mailMessage.Body = "Please Contact Help Desk #8000";    //mailMessage.Body = "Tony needs help,\n\nThis is a EPIMS test e-mail!";

            if (attachments != null)
            {
                foreach (KeyValuePair<string, Byte[]> attachment in attachments)
                {
                    Attachment mailAttachment = new Attachment(new MemoryStream(attachment.Value), attachment.Key);
                    mailMessage.Attachments.Add(mailAttachment);
                }
            }

            SmtpClient smtpClient = new SmtpClient("smtp2");
            smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;

            smtpClient.Port = 25;
            try
            {
                smtpClient.Send(mailMessage);
                smtpClient.Dispose();
                smtpClient = null;
                mailMessage.Dispose();
                mailMessage = null;
            }
            catch (ObjectDisposedException )
            {
                smtpClient.Dispose();
                smtpClient = null;
                mailMessage.Dispose();
                mailMessage = null;
                return false;   //var e = oe.InnerException;
            }
            catch (Exception )
            {
                smtpClient.Dispose();
                smtpClient = null;
                mailMessage.Dispose();
                mailMessage = null;
                return false;
            }                   
            return true;
        }
    }
}