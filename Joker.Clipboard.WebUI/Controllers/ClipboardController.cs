using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Joker.Clipboard.WebUI.Models.ClipboardViewModels;
using Joker.Clipboard.WebUI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Joker.Clipboard.WebUI.Controllers
{
    [Produces("application/json")]
    [Route("api/Clipboard")]
    public class ClipboardController : Controller
    {
        private readonly ClipboardManager ClipboardManager = new ClipboardManager();

        // GET: api/Clipboard
        [HttpGet]
        public IActionResult Get()
        {
            var result = string.Empty;
            if (IsAuthenticatedUser())
            {
                result = ClipboardManager.GetClipboard(GetCurrentUser());
            }
            else
            {
                result = ClipboardManager.GetAnonymousClipboard();
            }
            return Ok(result);
        }

        // POST: api/Clipboard
        [HttpPost]
        public IActionResult Post([FromBody]NewClipboardModel clipboard)
        {
            if (IsAuthenticatedUser())
            {
                ClipboardManager.SetClipboard(GetCurrentUser(), clipboard.NewClipboard);
            }
            else
            {
                ClipboardManager.SetAnonymousClipboard(clipboard.NewClipboard);
            }
            return Ok(new object());
        }

        private bool IsAuthenticatedUser()
        {
            return this.HttpContext.User.Identity.IsAuthenticated;
        }

        private string GetCurrentUser()
        {
            return this.HttpContext.User.Identity.Name;
        }
    }
}