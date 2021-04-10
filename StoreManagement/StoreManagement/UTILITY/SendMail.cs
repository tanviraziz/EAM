using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.IO;
using System.Data;

namespace StoreManagement.UTILITY
{
    class SendMail
    {
        //Send EMail Through OUTLOOK
        /// <summary>
        /// Send EMail Through OUTLOOK
        /// </summary>
        /// <param name="mailSubject"></param>
        /// <param name="mailBody"></param>
        /// <param name="mailAttachment"></param>
        /// <param name="mailToAddress"></param>
        /// <param name="mailCCAddress"></param>
        public Boolean sendEMailThroughOUTLOOK(string mailToAddress, string mailCCAddress, string mailSubject, string mailBody, string mailAttachment)
        {
            Outlook.Application oApp;
            Outlook.MailItem oMsg;
            Outlook.Recipients oRecips;
            try
            {
                // Create the Outlook application.
                oApp = new Outlook.Application();
                // Create a new mail item.
                oMsg = (Outlook.MailItem)oApp.CreateItem(Outlook.OlItemType.olMailItem);
                

                //Subject line
                oMsg.Subject = mailSubject;

                // Set HTMLBody and add the body of the email
                oMsg.HTMLBody = mailBody;

                //Add an attachment.
                String sDisplayName = "Attachment";
                int iPosition = (int)oMsg.Body.Length + 1;
                int iAttachType = (int)Outlook.OlAttachmentType.olByValue;
                //now attached the file
                Outlook.Attachment oAttach = oMsg.Attachments.Add(mailAttachment, iAttachType, iPosition, sDisplayName);

                // Add a recipient.
                oRecips = (Outlook.Recipients)oMsg.Recipients;
                // Change the recipient in the next line if necessary.
                //add the TO address in the recipients list
                Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(mailToAddress);
                oRecip.Type = (int)Outlook.OlMailRecipientType.olTo;//specify the address as TO address
                //if single address then send mail with below code
                //oRecip.Resolve();

                //if have cc addresses then have to add the following cc add lines
                //start:add the CC addresses in the recipients list
                if (!string.IsNullOrEmpty(mailCCAddress))
                {
                    string[] ccAddresss = mailCCAddress.Split(new Char[] { ',' });
                    foreach (string strCC in ccAddresss)
                    {
                        oRecips.Add(strCC);
                    }
                }

                oMsg.Recipients.ResolveAll();
                //end:add the CC addresses in the recipients list

                // Send mail
                oMsg.Send();
                oRecip = null;
                return true;

            }//end of try block
            catch (Exception ex)
            {
                return false;
            }//end of catch
            finally
            {
                // Clean up.                
                oRecips = null;
                oMsg = null;
                oApp = null;
            }//end of finally
        }//end of Email Method



        //send mail through SMTP
        /// <summary>
        /// Send mail through SMTP
        /// </summary>
        /// <param name="pdfFile"></param>
        private void Sendmail(string pdfFile, string msgSubject, string msgBody)
        {
            try
            {
                // Creating a new SMTP Client. The server URL/IP is indicated as
                // sendServer.Text (that is the text box with the data).
                SmtpClient client = new SmtpClient("222.222.222.26");
                // Creating a new mail message. The sender and receiver are
                // indicated as sendFrom.Text and SendTo.Text
                // (these are the text boxes with the data).
                MailMessage message = new MailMessage("dta@bpl.net", "dta@bpl.net");

                //message.From = new MailAddress("your_email_address@gmail.com");
                //message.To.Add("to_address");

                //message.To = "dta@bpl.net";
                //message.From = "from address here";

                // The message subject is located in the subjectBox.
                message.Subject = msgBody;

                // The message body is the message content provided in the
                // contentBox.
                message.Body = msgBody;

                message.Attachments.Add(new Attachment(pdfFile));

                // To be able to send the message, it is necessary to provide the
                // credentials on the server. The username is located in the userBox
                // and the password is located in the passBox.
                //client.Credentials = new System.Net.NetworkCredential(userBox.Text, passBox.Text);

                // Some servers require a specific port to connect,
                // so it is specified in the serverPort text box.
                //if (serverPort.Text != null)
                client.Port = 25;

                // Send the message.
                client.Send(message);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        //send mail through SMTP
        /// <summary>
        /// Send mail through SMTP
        /// </summary>
        /// <param name="pdfFile"></param>
        private void SendMailBySMTP(string mailToAddress, string mailCCAddress, string mailSubject, string mailBody, string mailAttachment)
        {
            try
            {
                // Creating a new SMTP Client. The server URL/IP is indicated as
                // sendServer.Text (that is the text box with the data).
                SmtpClient client = new SmtpClient("222.222.222.26");
                // Creating a new mail message. The sender and receiver are
                // indicated as sendFrom.Text and SendTo.Text
                // (these are the text boxes with the data).
                MailMessage message = new MailMessage();

                message.From = new MailAddress(mailToAddress);
                if (!string.IsNullOrEmpty(mailCCAddress))
                {
                    string[] ccAddresss = mailCCAddress.Split(new Char[] { ',' });
                    foreach (string strCC in ccAddresss)
                    {
                        message.To.Add(strCC);
                    }
                }                

                // The message subject is located in the subjectBox.
                message.Subject = mailSubject;

                // The message body is the message content provided in the contentBox.
                message.IsBodyHtml = true;
                message.Body = mailBody;

                if (!string.IsNullOrEmpty(mailAttachment))
                {
                    message.Attachments.Add(new Attachment(mailAttachment));
                }
                
                // Some servers require a specific port to connect,
                // so it is specified in the serverPort text box.
                //if (serverPort.Text != null)
                client.Port = 25;

                // To be able to send the message, it is necessary to provide the
                // credentials on the server. The username is located in the userBox
                // and the password is located in the passBox.
                //client.Credentials = new System.Net.NetworkCredential("username", "password");
                //client.EnableSsl = true;

                // Send the message.
                client.Send(message);

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }

        public void SendCEPMail(DataTable reqDT)
        {
            try
            {
                // Creating a new SMTP Client. The server URL/IP is indicated as
                // sendServer.Text (that is the text box with the data).
                SmtpClient client = new SmtpClient("222.222.222.26");
                // Creating a new mail message. The sender and receiver are
                // indicated as sendFrom.Text and SendTo.Text
                // (these are the text boxes with the data).
                MailMessage message = new MailMessage("dta@bpl.net", "dta@bpl.net");

                //message.From = new MailAddress("your_email_address@gmail.com");
                //message.To.Add("to_address");

                //message.To = "dta@bpl.net";
                //message.From = "from address here";
                message.IsBodyHtml = true;

                // The message subject is located in the subjectBox.
                message.Subject = "Test Mail";

                //***********************************************************
                string strLink = "http://222.222.222.217:1080/SRR/index";
                StringBuilder sbody = new StringBuilder();

                sbody.Append("<!DOCTYPE html>");
                sbody.Append("<html>");
                sbody.Append("<head>");
                sbody.Append("<style>");
                sbody.Append("table, td, th");
                sbody.Append("{");
                sbody.Append("border:1px solid green;");
                sbody.Append("}");
                sbody.Append("th");
                sbody.Append("{");
                sbody.Append("background-color:green;");
                sbody.Append("color:white;");
                sbody.Append("}");
                sbody.Append("</style>");
                sbody.Append("</head>");
                sbody.Append("<body>");
                sbody.Append("<table>");
                sbody.Append("<tr><th>Item</th><th>Unit</th><th>Req Qty</th></tr>");
                //sbody.Append("<tr><td>Peter</td><td>Griffin</td><td>$100</td></tr>");
                //sbody.Append("<tr><td>Lois</td><td>Griffin</td><td>$150</td></tr>");
                //sbody.Append("<tr><td>Joe</td><td>Swanson</td><td>$300</td></tr>");
                
                if (reqDT != null && reqDT.Rows.Count > 0)
                {
                    foreach (DataRow dr in reqDT.Rows)
                    {
                        sbody.Append("<tr>");
                        sbody.Append("<td>" + dr["Item"].ToString().Trim() + "</td>");
                        sbody.Append("<td>" + dr["Unit"].ToString().Trim() + "</td>");
                        sbody.Append("<td>" + dr["OrderedQty"].ToString().Trim() + "</td>");
                        sbody.Append("</tr>");
                    }
                }
                

                sbody.Append("<tr><td><a href=" + '"' + strLink + '"' + " " + "target=" + '"' + "_blank" + '"' + ">Requisition Detail</a></td></tr>");
                sbody.Append("</table>");
                sbody.Append("</body>");
                sbody.Append("</html>");
                //***********************************************************

                // The message body is the message content provided in the
                // contentBox.
                message.Body = sbody.ToString();

                //message.Attachments.Add(new Attachment(null));

                // To be able to send the message, it is necessary to provide the
                // credentials on the server. The username is located in the userBox
                // and the password is located in the passBox.
                //client.Credentials = new System.Net.NetworkCredential(userBox.Text, passBox.Text);

                // Some servers require a specific port to connect,
                // so it is specified in the serverPort text box.
                //if (serverPort.Text != null)
                client.Port = 25;

                // Send the message.
                client.Send(message);

                //MessageBox.Show("mail Send");

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
    }
}
