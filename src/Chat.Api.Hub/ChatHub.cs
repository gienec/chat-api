using System;
using System.Collections.Generic;
using Chat.Api.Models;
using Chat.Api.Repositories;
using Chat.Api.Repositories.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.Api.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IUserRepository _userRepository;
        private readonly IChannelRepository _channelRepository;
        public ChatHub(IUserRepository userRepository, IChannelRepository channelRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _channelRepository = channelRepository ?? throw new ArgumentNullException(nameof(channelRepository));
        }

        public void CreateUser(string token, string name)
        {
            _userRepository.Create(token, 
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name
                });
        }

        public IList<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public void GetUserChannels()
        {
            Clients.Caller.SendAsync("receive-channel", _channelRepository.GetById("lobby"));
        }

        public void SendMessage(Message message)
        {
            message.Timestamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds();

            Clients.All.SendAsync("receive-message", message);

            _channelRepository.AddMessage(message);
        }
    }
}
