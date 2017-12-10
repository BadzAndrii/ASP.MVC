using System;
using System.IO;

namespace Lab2Server.Extensions
{
    public static class PhotosExtension
    {
        public static byte[] ToBlob(this Stream fileStream)
        {
            if (fileStream == null) return null;

            using (var memStream = new MemoryStream())
            {
                fileStream.CopyTo(memStream);
                return memStream.ToArray();
            }
        }

        public static string ToImageSource(this byte[] bytes)
        {
            return $"data:image/png;base64,{Convert.ToBase64String(bytes)}";
        }
    }
}