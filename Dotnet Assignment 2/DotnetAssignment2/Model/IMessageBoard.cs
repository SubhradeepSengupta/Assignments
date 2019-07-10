using System.Collections.Generic;

namespace DotnetAssignment2.Model
{
    public interface IMessageBoard
    {
        IEnumerable<Message> GetMessage();
        Message GetById(int Id);
        Message Add(Message newMessage);
        Message Update(Message updatedMessage);
    }
}
