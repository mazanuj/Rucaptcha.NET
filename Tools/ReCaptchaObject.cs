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
        private string _Challenge;

        /// <summary>
        /// Значение поля recaptcha_challenge_field
        ///             Используется для отправки капчи
        /// 
        /// </summary>
        public string Challenge
        {
            get { return _Challenge; }
        }

        /// <summary>
        /// URL изображения
        /// 
        /// </summary>
        public string ImageURL
        {
            get { return string.Format("http://www.google.com/recaptcha/api/image?c={0}", (object) _Challenge); }
        }

        public ReCaptchaObject(string Chall)
        {
            _Challenge = Chall;
        }

        /// <summary>
        /// Загружает изображение капчи средствами стандартного WebClient, без дополнительных заголовков
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public byte[] ImageData()
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
                return Image.FromStream((Stream) memoryStream);
        }
    }
}