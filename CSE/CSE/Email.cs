using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CSE
{
    class Email
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
