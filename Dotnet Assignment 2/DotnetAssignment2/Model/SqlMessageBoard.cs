using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DotnetAssignment2.Model
{
    public class SqlMessageBoard : IMessageBoard
    {
        private readonly MessageDbContext db;

        public SqlMessageBoard(MessageDbContext db)
        {
            this.db = db;
        }

        public Message Add(Message newMessage)
        {
            try
            {
                db.Add(newMessage);
                db.SaveChanges();
                return newMessage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Message GetById(int Id)
        {
            return db.data.Find(Id);
        }

        public IEnumerable<Message> GetMessage()
        {
            try
            {
                var query = from m in db.data
                            orderby m.Id
                            select m;
                return query;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Message Update(Message updatedMessage)
        {
            var entity = db.data.Attach(updatedMessage);   //tracks changes for the Message object that's already in there
            entity.State = EntityState.Modified;
            return updatedMessage;
        }
    }
}
