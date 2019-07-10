using DotnetAssignment1.core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DotnetAssignment1.data
{
    public interface IMessageBoard
    {
        IEnumerable<Message> GetMessage();
        Message GetById(int Id);
        Message Add(Message newMessage);
        Message Update(Message updatedMessage);
        int Commit();
    }

    public class SqlMessagBoard : IMessageBoard
    {
        private readonly MessageDbContext db;

        public SqlMessagBoard(MessageDbContext db)
        {
            this.db = db;
        }

        public Message Add(Message newMessage)
        {
            db.Add(newMessage);
            Commit();
            return newMessage;
        }

        public int Commit()
        {
            return db.SaveChanges();                    //returns an integer value that returns the effected row of the db
        }

        public Message GetById(int Id)
        {
            return db.Messages.Find(Id);                //passing the primary key value for the entity framework to find
        }

        public IEnumerable<Message> GetMessage()
        {
            var query = from m in db.Messages
                        orderby m.Id
                        select m;
            return query;
        }

        public Message Update(Message updatedMessage)
        {
           var entity = db.Messages.Attach(updatedMessage);   //tracks changes for the Message object that's already in there
            entity.State = EntityState.Modified;
            return updatedMessage;
        }
    }
}
