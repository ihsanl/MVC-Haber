using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace MvcEmlak.Models
{
    public static class SecurityHelper
    {
        public static string GenerateMD5Hex(this string Exp)
        {
            var _md5 = MD5.Create();
            var _result = _md5.ComputeHash(Encoding.Default.GetBytes(Exp));
            StringBuilder _sb = new StringBuilder();
            foreach (var item in _result)
                _sb.Append(item.ToString("X2"));
            return _sb.ToString();
        }

    }
}