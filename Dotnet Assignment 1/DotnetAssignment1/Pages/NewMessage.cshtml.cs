using System;
using System.Collections.Generic;
using DotnetAssignment1.core;
using DotnetAssignment1.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotnetAssignment1.Pages
{
    public class NewMessageModel : PageModel
    {
        private IMessageBoard messages;

        [BindProperty]
        public Message message { get; set; }

        public NewMessageModel(IMessageBoard messages)
        {
            this.messages = messages;
        }

        public void OnGet(int id)
        {
            message = messages.GetById(id);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                messages.Add(message);
            }
            return RedirectToPage("./MessageBoard");
        }
    }
}