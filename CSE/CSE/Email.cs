using System;
using System.Net.Mail;

namespace CSE
{
    public class Email
    {
        public bool IsValid(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            } catch (FormatException)
            {
                return false;
            }
            catch(ArgumentException)
            {
                return false;
            }
        }
    }
}
