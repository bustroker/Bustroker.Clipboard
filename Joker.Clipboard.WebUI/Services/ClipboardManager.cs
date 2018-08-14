using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joker.Clipboard.WebUI.Services
{
    public class ClipboardManager
    {
        private static IDictionary<string, string> UsersClipboards = new Dictionary<string, string>();

        public string GetClipboard(string userName)
        {
            var result = string.Empty;
            UsersClipboards.TryGetValue(userName, out result);
            return result;
        }

        public void SetClipboard(string userName, string content)
        {
            if (UsersClipboards.ContainsKey(userName))
            {
                UsersClipboards[userName] = content;
            }
            else
            {
                UsersClipboards.Add(userName, content);
            }
        }
    }
}
