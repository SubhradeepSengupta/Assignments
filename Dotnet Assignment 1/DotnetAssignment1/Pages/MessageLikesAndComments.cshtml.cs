using DotnetAssignment1.core;
using DotnetAssignment1.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DotnetAssignment1.Pages
{
    public class MessageLikesAndCommentsModel : PageModel
    {
        private readonly IMessageBoard messages;

        [BindProperty]
        public Message message { get; set; }

        public MessageLikesAndCommentsModel(IMessageBoard messages)  //services for getting the messages
        {
            this.messages = messages;
        }

        public void OnGet(int id)
        {
            message = messages.GetById(id);
        }

        public IActionResult OnPost(string submit, string Comment)
        {
            switch (submit)
            {
                case "cmnt":
                    messages.Update(message);
                    messages.Commit();
                    break;
                case "lyk":
                    message.Like += 1;
                    messages.Update(message);
                    messages.Commit();
                    break;
            }
            return RedirectToPage("./MessageBoard");
        }

        
    }
}