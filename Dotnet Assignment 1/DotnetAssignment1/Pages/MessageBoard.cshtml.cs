using System.Collections.Generic;
using DotnetAssignment1.core;
using DotnetAssignment1.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DotnetAssignment1.Pages
{
    public class MessageBoardModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IMessageBoard messages;
        public IEnumerable<Message> Messages { get; set; }

        public MessageBoardModel(IConfiguration config, IMessageBoard messages)  //services for getting the messages
        {
            this.config = config;
            this.messages = messages;
        }

        public void OnGet()
        {
            Messages = messages.GetMessage();
        }
    }
}