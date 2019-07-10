using DotnetAssignment1.core;
using Microsoft.EntityFrameworkCore;

namespace DotnetAssignment1.data
{
    public class MessageDbContext : DbContext               //inherits from the DbContext class of Microsoft.EntityFrameworkCore
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options)  //sending the options to the base class constructor
            : base(options)
        {

        }

        public DbSet<Message> Messages { get; set; }        //not only query from the db but also insert update and delete in db
    }
}
