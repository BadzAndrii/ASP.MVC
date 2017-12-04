using System;

namespace Lab2Server.Extensions
{
    public static class PhotosExtension
    {
        public static string ToBase64String(this byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
    }
}