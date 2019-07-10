using DotnetAssignment1.core;
using System.Collections.Generic;
using System.Linq;

namespace DotnetAssignment1.data
{
    public class MessageBoard : IMessageBoard
    {
        readonly List<Message> messages;

        public MessageBoard()
        {
            messages = new List<Message>()
            {
                new Message { Id = 1, Name = "Rahul", UserMessage = "Hello World" },
                new Message { Id = 2, Name = "Subhra", UserMessage = "Asp.net project" },
            };
        }

        public IEnumerable<Message> GetMessage()
        {
            return from r in messages
                   orderby r.Id
                   select r;
        }

        public Message GetById(int Id)
        {
            return messages.SingleOrDefault(i => i.Id == Id);
        }

        public Message Add(Message newMessage)
        {
            messages.Add(newMessage);
            newMessage.Id = messages.Max(i => i.Id) + 1;
            return newMessage;
        }

        public Message Update(Message updatedMessage)
        {
            return updatedMessage;
        }

        public int Commit()
        {
            return 0;
        }
    }
}
