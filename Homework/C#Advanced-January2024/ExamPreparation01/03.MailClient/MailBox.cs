using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new();
            Archive = new();
        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity)
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            Mail currentMail = Inbox.FirstOrDefault(mail => mail.Sender == sender);
            if (currentMail != null)
            {
                Inbox.Remove(currentMail);
                return true;
            }

            return false;
        }

        public int ArchiveInboxMessages()
        {
            int mailsMoved = 0;

            for (int i = 0; i < Inbox.Count; i++)
            {
                Archive.Add(Inbox[i]);
                mailsMoved++;
            }

            Inbox.Clear();

            return mailsMoved;
        }

        public string GetLongestMessage()
        {
            Mail currentMail = default;
            int longestMessage = int.MinValue;

            foreach (Mail mail in Inbox)
            {
                if (mail.Body.Length > longestMessage)
                {
                    longestMessage = mail.Body.Length;
                    currentMail = mail;
                }
            }

            return currentMail.ToString();
        }

        public string InboxView()
        {
            StringBuilder sb = new();

            sb.AppendLine("Inbox:");

            foreach (Mail mail in Inbox)
            {
                sb.AppendLine(mail.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
