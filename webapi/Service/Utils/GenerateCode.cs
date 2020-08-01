using System;

namespace Service.Utils
{
    public static class GenerateCode
    {
        public static string EmailCode()
        {
            var guid = Guid.NewGuid().ToString();

            var code = guid.Substring(0, 6).ToUpper();

            return code;
        }
    }
}
