using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Chat.Api.Models;

namespace Chat.Api.Repositories
{
    public interface IChannelRepository
    {
        IList<Channel> GetUserChannels(string userId);
        Channel GetById(string id);
        void AddMessage(Message message);
    }

    public class ChannelRepository : IChannelRepository
    {
        private ConcurrentBag<Channel> _channels;

        public ChannelRepository()
        {
            _channels = new ConcurrentBag<Channel>
            {
                new Channel
                {
                    Id = "lobby"
                }
            };
        }

        public IList<Channel> GetUserChannels(string userId)
        {
            return _channels.Where(c => c.Users.FirstOrDefault(u => u.Equals(userId)) != null).ToList();
        }

        public Channel GetById(string id)
        {
            return _channels.FirstOrDefault(c => c.Id.Equals(id));
        }

        public void AddMessage(Message message)
        {
            Channel channel = GetById(message.ChannelId);
            channel.Messages.Add(message);
        }
    }
}