using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemCRUDWeb.StaticDetails
{
    public static class SD
    {
        public static string APIBaseUrl = "https://localhost:44302/";
        public static string ItemAPIPath = APIBaseUrl + "api/items/";
        public static string AccountAPIPath = APIBaseUrl + "api/Users/";
    }
}
