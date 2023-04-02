using Microsoft.AspNetCore.Mvc;
using ShopBuy7.Data;
using SixLabors.ImageSharp.Formats.Jpeg;
using System.Net.Mail;

namespace ShopBuy7.Models
{
    public class Global
    {
        
        public static string apiPath { get; set; } = "https://localhost:44342/api/";
        public static string ImagePath { get; set; } = "";
        public static string Currancy { get; set; } = "Rs ";
        public static List<Category> Categories { get; set; } = new();
        public static List<SubCategory> SubCategories { get; set; } = new();
        public static List<Product> featured { get; set; } = new();
        public static List<Product> onSale { get; set; } = new();
        public static List<Product> topRated { get; set; } = new();

        public static DateTime SetDateTime()
        {
            return DateTime.Now;
        }



        // Compress Image

        [HttpPost]
        public static string UploadMainImg(IWebHostEnvironment _host, IFormFile file, string name, int id, char type)
        {
            string rootPath = _host.WebRootPath;
            string ImgFolder = "";
            if (type == 'c')
            {
                ImgFolder = rootPath + "/Images/Categories/";
            }
            else if (type == 'r')
            {
                ImgFolder = rootPath + "/Images/Ranks/";
            }
            else if (type == 'b')
            {
                ImgFolder = rootPath + "/Images/Banners/";
            }
            // If directory does not exist, create it. 
            if (!Directory.Exists(ImgFolder))
            {
                Directory.CreateDirectory(ImgFolder);
            }
            if (name != "NotFound.png")
            {
                var imagePath = Path.Combine(ImgFolder + "/" + name);
                if (File.Exists(imagePath))
                {
                    File.Delete(imagePath);
                }
            }

            string FileExtension = Path.GetExtension(file.FileName);
            string fileName = id + "-" + DateTime.Now.ToString("yymmssfff") + FileExtension;
            string path = Path.Combine(ImgFolder + "/", fileName);

            using (var imageStream = new MemoryStream())
            {
                file.CopyTo(imageStream);
                imageStream.Seek(0, SeekOrigin.Begin);

                using (var output = new MemoryStream())
                using (var image = Image.Load(imageStream))
                {
                    image.Mutate(x => x.Resize(new ResizeOptions
                    {
                        Size = new Size(800, 800),
                        Mode = ResizeMode.Max
                    }));

                    image.Save(path, new JpegEncoder());

                    return fileName;
                }
            }
        }


        // Email verification
        public static void EmailVerification(string to, string subject, string Innerbody)
        {
            string from = "taajpkofficial@gmail.com";
            string Host = "smtp.gmail.com";
            int Port = 587;

            //string body = header + Innerbody + footer;
            MailMessage message = new(from, to, subject, Innerbody)
            {
                IsBodyHtml = true
            };
            SmtpClient client = new(Host, Port);
            client.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "taajpkofficial@gmail.com",
                Password = "pwgikvsyqqnpojtc"
            };
            client.EnableSsl = true;
            client.Send(message);
        }

        public static void EmailNotification(string to, string subject, string Innerbody)
        {
            string from = "taajpkofficial@gmail.com";
            string Host = "smtp.gmail.com";
            int Port = 587;

            //string body = header + Innerbody + footer;
            MailMessage message = new(from, to, subject, Innerbody)
            {
                IsBodyHtml = true
            };
            SmtpClient client = new(Host, Port);
            client.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "taajpkofficial@gmail.com",
                Password = "pwgikvsyqqnpojtc"
            };
            client.EnableSsl = true;
            client.Send(message);
        }

    }
}
