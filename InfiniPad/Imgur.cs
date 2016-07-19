using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;
using System.Xml.Linq;

namespace InfiniPad
{
    static class Imgur
    {
        public readonly static string FileFilter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|All Files (*.*)|*.*";
        public struct ImgurInfo
        {
            public Uri link;
            public string deletehash;

            public ImgurInfo(Uri lnk, string delhash)
            {
                link = lnk;
                deletehash = delhash;
            }
        };
        public static ImgurInfo toImgur(Bitmap bmp)
        {
            ImageConverter convert = new ImageConverter();
            byte[] toSend = (byte[])convert.ConvertTo(bmp, typeof(byte[]));
            using (WebClient wc = new WebClient())
            {
                NameValueCollection nvc = new NameValueCollection
                {
                    { "image", Convert.ToBase64String(toSend) }
                };
                wc.Headers.Add("Authorization", "Client-ID " + APIKeys.ImgurClientID);
                byte[] response = wc.UploadValues("https://api.imgur.com/3/upload.xml", nvc);
                string res = XDocument.Load(new MemoryStream(response)).ToString();
                int start = res.IndexOf("<link>") + 6;
                int len = res.IndexOf("</link>") - start;
                int starthash = res.IndexOf("<deletehash>") + 12;
                int lenhash = res.IndexOf("</deletehash>") - starthash;
                return new ImgurInfo(new Uri(res.Substring(start, len)), res.Substring(starthash, lenhash));
            }
        }
        public static void deleteImage(ImgurInfo info)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("Authorization", "Client-ID " + APIKeys.ImgurClientID);
                byte[] response = wc.UploadValues(String.Format("https://api.imgur.com/3/image/{0}", info.deletehash), "DELETE", new NameValueCollection());
            }
        }
    }
}
