using System.Text;

namespace Ychao.OpenAGI
{
    // smsurl = "https://sms-activate.org/"
    class OpenKey
    {
        static byte[] AccountBytes = { 115, 107, 45, 117, 105, 98, 100, 106, 66, 107, 117, 48, 104, 56, 103, 100, 120, 115, 122, 106, 86, 72, 67, 84, 51, 66, 108, 98, 107, 70, 74, 74, 90, 71, 48, 76, 115, 69, 69, 119, 74, 87, 50, 74, 121, 76, 80, 113, 53, 110, 88 };
        static byte[] SkBytes = { 74, 105, 109, 114, 121, 89, 99, 104, 97, 111, 45, 79, 112, 101, 110, 65, 73 };

        public static string ToString(byte[] buffer)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in buffer)
                sb.Append((char)item);
            return sb.ToString();
        }
    }
}
