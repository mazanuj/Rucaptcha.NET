using System;

namespace Akumu.Antigate
{
    /// <summary>
    /// Экземпляр исключения выбрасываемого в ситуации, когда Antigate отвечает ERROR сообщением.
    /// 
    /// </summary>
    public class AntigateErrorException : Exception
    {
        private readonly RucaptchaError Error;

        public AntigateErrorException(RucaptchaError Error)
            : base(VerbalError(Error))
        {
            this.Error = Error;
        }

        /// <summary>
        /// Возвращает RucaptchaError значение исключения
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public RucaptchaError GetError()
        {
            return Error;
        }

        private static string VerbalError(RucaptchaError status)
        {
            switch (status)
            {
                case RucaptchaError.WRONG_USER_KEY:
                    return "Antigate secret key has invalid format";
                case RucaptchaError.KEY_DOES_NOT_EXIST:
                    return "Wrong antigate secret key";
                case RucaptchaError.ZERO_BALANCE:
                    return "Zero antigate balance";
                case RucaptchaError.ZERO_CAPTCHA_FILESIZE:
                    return "Image file has zero size";
                case RucaptchaError.TOO_BIG_CAPTCHA_FILESIZE:
                    return "Image file size too big";
                case RucaptchaError.WRONG_FILE_EXTENSION:
                    return "Wrong file extension";
                case RucaptchaError.IMAGE_TYPE_NOT_SUPPORTED:
                    return "Image type not supported";
                case RucaptchaError.IP_NOT_ALLOWED:
                    return "IP not allowed";
                case RucaptchaError.WRONG_ID_FORMAT:
                    return "Wrong captcha ID";
                case RucaptchaError.CAPTCHA_UNSOLVABLE:
                    return "Captcha unsolvable";
                default:
                    return string.Empty;
            }
        }
    }
}