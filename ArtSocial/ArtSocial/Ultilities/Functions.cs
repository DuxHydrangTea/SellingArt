using System;
using System.Security.Cryptography;
using System.Text;

namespace ArtSocial.Utilities
{
    public class Functions
    {

        // -------- Message ------------//
        public static string _Message = string.Empty;


        //--------------- User --------------//
        public static int _UserID = 0;
        public static string _UserName = String.Empty;
        public static string _Email = String.Empty;
        public static bool _isLogin = false; 

        //-------------------ADmin----------------//
        public static int _AdminID = 0;
        public static string _AdminUser = String.Empty;
        public static string _AdminAvatar = String.Empty;
        //public static string TitleSlugGeneration(string Type, string title, long id)
        //{
        //    string sTitle = Type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
        //    return sTitle;
        //}
        // ----------- Upload Access -------------//
        public static string _uploaddone = String.Empty;





        public static string MD5Hash(string text)
        {
            MD5 mD5 = new MD5CryptoServiceProvider();
            mD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = mD5.Hash;
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                stringBuilder.Append(result[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
        public static string MD5Password(string? text)
        {
            string str = MD5Hash(text);
            for (int i = 0; i < 5; i++)
            {
                str = MD5Hash(str.Substring(0,2) + "@"+str);
            }
            return str;
        }
        public static bool IsLogin()
        {
            if (string.IsNullOrEmpty(Functions._UserName) || (Functions._UserID <= 0))
                return false;
            return true;
        }

        public static string getCurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }


    }
    }
