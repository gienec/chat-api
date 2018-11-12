using System;

namespace Chat.Api.Models
{
    public class Message
    {
        public string Id { set; get; }
        public long Timestamp { set; get; }
        public string ChannelId { get; set; }
        public string UserName { get; set; }
        public string Text { get; set; }
    }
}
