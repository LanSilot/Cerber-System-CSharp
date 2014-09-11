using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.IO;

namespace CloudinaryManager
{
    public class CloudinaryManagerEx
    {
        private Cloudinary cloudinary;
        private Account account;

        public CloudinaryManagerEx(String cloudName, String apiKey, String apiSecret)
        {
            account = new Account(cloudName, apiKey, apiSecret);
            cloudinary = new Cloudinary(account);
        }

        public String UploadImage(String path)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path),
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            if (uploadResult != null)
                return uploadResult.Uri.AbsoluteUri;
            else
                return "";
        }

        public String UploadImage(String path, String guid)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(path),
                PublicId = guid
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            if (uploadResult != null)
                return uploadResult.Uri.AbsoluteUri;
            else
                return "";
        }

        public String UploadImage(String name, Stream stream, String guid)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(name, stream),
                PublicId = guid
            };

            var uploadResult = cloudinary.Upload(uploadParams);
            if (uploadResult != null)
                return uploadResult.Uri.AbsoluteUri;
            else
                return "";
        }
    }
}
