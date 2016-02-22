using System.Drawing;
using System.IO;
using System.Net;

namespace Akumu.Antigate.Tools
{
    /// <summary>
    /// Класс объекта капчи reCAPCHA.
    ///             Содержит в себе значение переменной recaptcha_challenge_field, а так же вспомогательные методы связанные с ним.
    /// 
    /// </summary>
    public class ReCaptchaObject
    {
        /// <summary>
        /// Значение поля recaptcha_challenge_field
        ///             Используется для отправки капчи
        /// 
        /// </summary>
        private string Challenge { get; }

        /// <summary>
        /// URL изображения
        /// 
        /// </summary>
        private string ImageURL => $"http://www.google.com/recaptcha/api/image?c={Challenge as object}";

        public ReCaptchaObject(string Chall)
        {
            Challenge = Chall;
        }

        /// <summary>
        /// Загружает изображение капчи средствами стандартного WebClient, без дополнительных заголовков
        /// 
        /// </summary>
        /// 
        /// <returns/>
        private byte[] ImageData()
        {
            using (var webClient = new WebClient())
                return webClient.DownloadData(ImageURL);
        }

        /// <summary>
        /// Интерпретирует вывод функции ReCaptchaObject.ImageData в виде объекта Image
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public Image ImageObject()
        {
            using (var memoryStream = new MemoryStream(ImageData()))
                return Image.FromStream(memoryStream);
        }
    }
}