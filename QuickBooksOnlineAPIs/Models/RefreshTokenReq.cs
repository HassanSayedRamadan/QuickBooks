using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickBooksOnlineAPIs.Models
{
    public class RefreshTokenReq
    {
        public string grant_type { get; set; }
        public string refresh_token { get; set; }
    }
}