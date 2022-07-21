using System.Text.RegularExpressions;

namespace GuestWhoIAm.Models
{
    public class EntryValidator
    {



        public bool Validate(Entry entry)
        {
            var nameToValidate = entry.Author;
            var contentToValidate = entry.Content;
            var emailToValidate = entry.Email;
            bool checkedContent = CheckedContent(contentToValidate);
            bool checkedMail = CheckEmail(emailToValidate);

            if (nameToValidate == null || contentToValidate == null || emailToValidate == null || checkedMail == false || checkedContent == false)
            {
                return false;
            }
            else return true;


        }

        private bool CheckedContent(string contentToValidate)
        {
            Regex regex = new Regex(@"^.{0,500}$");
            Match match = regex.Match(contentToValidate);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckEmail(string emailToValidate)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(emailToValidate);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
