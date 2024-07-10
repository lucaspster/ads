namespace Ads.Models;

using Ads.Models;

public class Message
{
    public int MessageID { get; set; }
    public string SenderID { get; set; }
    public User Sender { get; set; }
    public string ReceiverID { get; set; }
    public User Receiver { get; set; }
    public string Messages { get; set; }
    public DateTime SentAt { get; set; }
}