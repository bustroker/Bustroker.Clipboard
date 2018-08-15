using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Joker.Clipboard.WebUI.Models.ClipboardViewModels;

namespace Joker.Clipboard.WebUI.Services
{
    public class ClipboardManager
    {
        private static string AnonymousUserClipboard = string.Empty;
        private static IDictionary<string, string> AuthenticatedUsersClipboards = new Dictionary<string, string>();

        public string GetClipboard(string userName)
        {
            var result = string.Empty;
            AuthenticatedUsersClipboards.TryGetValue(userName, out result);
            return result;
        }

        public void SetClipboard(string userName, string content)
        {
            if (AuthenticatedUsersClipboards.ContainsKey(userName))
            {
                AuthenticatedUsersClipboards[userName] = content;
            }
            else
            {
                AuthenticatedUsersClipboards.Add(userName, content);
            }
        }

        public void SetAnonymousClipboard(string content)
        {
            AnonymousUserClipboard = content;
        }

        public string GetAnonymousClipboard()
        {
            return AnonymousUserClipboard;
        }
    }
}
