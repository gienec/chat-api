using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Chat.Api.Models
{
    public class Channel
    {
        public string Id { get; set; }
        public IList<string> Users { get; set; }
        public ConcurrentBag<Message> Messages { get; set; }

        public Channel()
        {
            Messages = new ConcurrentBag<Message>();
            Users = new List<string>();
        }
    }
}