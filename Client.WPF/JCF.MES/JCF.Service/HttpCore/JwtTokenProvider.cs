using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCF.Service.HttpCore
{
    public static class JwtTokenProvider
    {
        private static string? _token;

        public static void SetToken(string token)
        {
            _token = token;
        }

        public static string? GetToken()
        {
            return _token;
        }

        public static void Clear()
        {
            _token = null;
        }
    }
}
