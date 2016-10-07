using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace InfiniPad
{
    static class Imgur
    {
        public readonly static string FileFilter = "JPEG Image|*.jpg|PNG Image|*.png|Bitmap Image|*.bmp|All Files (*.*)|*.*";
        public struct ImageInfo
        {
            public Uri link;
            public string deletehash;
            public string id;
            public bool success;
            public Exception ex;
        };
        public struct AuthInfo
        {
            public string access_token;
            public string expires_in;
            public string token_type;
            public string scope;
            public string refresh_token;
            public int account_id;
            public string account_username;
            public bool success;
            public Exception ex;
        }
        public struct Account
        {
            public int id;
            public string url;
            public string bio;
            public float reputation;
            public int created;
            public int pro_expiration;
            public bool success;
            public Exception ex;
        }

        #region Auth
        private static string getAuth()
        {
            if (Properties.Settings.Default.account_authed && Properties.Settings.Default.UploadWithAccount)
                return getAuthBearer();
            else
                return getAuthClient();
        }
        private static string getAuthBearer()
        {
            return "Bearer " + Properties.Settings.Default.account_access_token;
        }
        private static string getAuthClient()
        {
            return "Client-ID " + APIKeys.ImgurClientID;
        }
        #endregion

        public static ImageInfo toImgur(Bitmap bmp)
        {
            ImageConverter convert = new ImageConverter();
            byte[] toSend = (byte[])convert.ConvertTo(bmp, typeof(byte[]));
            using (WebClient wc = new WebClient())
            {
                NameValueCollection nvc = new NameValueCollection
                {
                    { "image", Convert.ToBase64String(toSend) }
                };
                wc.Headers.Add("Authorization", Imgur.getAuth());
                ImageInfo info = new ImageInfo();
                try  
                {
                    byte[] response = wc.UploadValues("https://api.imgur.com/3/upload.xml", nvc);
                    string res = System.Text.Encoding.Default.GetString(response);

                    var xmlDoc = new System.Xml.XmlDocument();
                    xmlDoc.LoadXml(res);
                    info.link = new Uri(xmlDoc.SelectSingleNode("data/link").InnerText);
                    info.deletehash = xmlDoc.SelectSingleNode("data/deletehash").InnerText;
                    info.id = xmlDoc.SelectSingleNode("data/id").InnerText;
                    info.success = true;
                }
                catch (Exception e)
                {
                    info.success = false;
                    info.ex = e;
                }
                return info;
            }
        }
        public static void deleteImage(ImageInfo info)
        {
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("Authorization", Imgur.getAuth());
                byte[] response = wc.UploadValues(String.Format("https://api.imgur.com/3/image/{0}", info.deletehash), "DELETE", new NameValueCollection());
            }
        }

        public static AuthInfo authAccount(string pin)
        {
            using (WebClient wc = new WebClient())
            {
                NameValueCollection nvc = new NameValueCollection
                {
                    {"client_id", APIKeys.ImgurClientID },
                    {"client_secret", APIKeys.ImgurClientSecret },
                    {"grant_type", "pin" },
                    {"pin", pin },
                };
                wc.Headers.Add("Authorization", Imgur.getAuth());
                AuthInfo info = new AuthInfo();
                try
                {
                    byte[] response = wc.UploadValues("https://api.imgur.com/oauth2/token", nvc);
                    string res = System.Text.Encoding.Default.GetString(response);
                    var JsonReader = JsonReaderWriterFactory.CreateJsonReader(response, new System.Xml.XmlDictionaryReaderQuotas());
                    var root = System.Xml.Linq.XElement.Load(JsonReader);
                    info.access_token = root.Element("access_token").Value;
                    info.expires_in = root.Element("expires_in").Value;
                    info.token_type = root.Element("token_type").Value;
                    info.scope = root.Element("scope").Value;
                    info.refresh_token = root.Element("refresh_token").Value;
                    info.account_id = Int32.Parse(root.Element("account_id").Value);
                    info.account_username = root.Element("account_username").Value;
                    info.success = true;
                }
                catch (Exception e)
                {
                    info.success = false;
                    info.ex = e;
                }
                return info;

            }
        }
        public static Account accountInfo(int account_id)
        {
            Account acc = new Account();
            using (WebClient wc = new WebClient()){
                wc.Headers.Add("Authorization", Imgur.getAuthBearer());
                try
                {
                    byte[] response = wc.DownloadData("https://api.imgur.com/3/account/me");
                    string res = System.Text.Encoding.Default.GetString(response);
                    var JsonReader = JsonReaderWriterFactory.CreateJsonReader(response, new System.Xml.XmlDictionaryReaderQuotas());
                    var root = System.Xml.Linq.XElement.Load(JsonReader);
                    acc.id = Int32.Parse(root.Element("data").Element("id").Value);
                    acc.url = root.Element("data").Element("url").Value;
                    acc.bio = root.Element("data").Element("bio").Value;
                    acc.reputation = float.Parse(root.Element("data").Element("reputation").Value);
                    acc.created = Int32.Parse(root.Element("data").Element("created").Value);
                    if (!Int32.TryParse(root.Element("data").Element("pro_expiration").Value, out acc.pro_expiration))
                    {
                        acc.pro_expiration = 0;
                    }
                    acc.success = true;
                }
                catch (Exception e)
                {
                    acc.success = false;
                    acc.ex = e;
                }
                
            }
            return acc;
        }
    }
}
