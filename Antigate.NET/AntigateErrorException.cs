using System;

namespace Akumu.Antigate
{
    /// <summary>
    /// Экземпляр исключения выбрасываемого в ситуации, когда Antigate отвечает ERROR сообщением.
    /// 
    /// </summary>
    public class AntigateErrorException : Exception
    {
        private readonly AntigateError Error;

        public AntigateErrorException(AntigateError Error)
            : base(VerbalError(Error))
        {
            this.Error = Error;
        }

        /// <summary>
        /// Возвращает AntigateError значение исключения
        /// 
        /// </summary>
        /// 
        /// <returns/>
        public AntigateError GetError()
        {
            return Error;
        }

        private static string VerbalError(AntigateError status)
        {
            switch (status)
            {
                case AntigateError.WRONG_USER_KEY:
                    return "Antigate secret key has invalid format";
                case AntigateError.KEY_DOES_NOT_EXIST:
                    return "Wrong antigate secret key";
                case AntigateError.ZERO_BALANCE:
                    return "Zero antigate balance";
                case AntigateError.ZERO_CAPTCHA_FILESIZE:
                    return "Image file has zero size";
                case AntigateError.TOO_BIG_CAPTCHA_FILESIZE:
                    return "Image file size too big";
                case AntigateError.WRONG_FILE_EXTENSION:
                    return "Wrong file extension";
                case AntigateError.IMAGE_TYPE_NOT_SUPPORTED:
                    return "Image type not supported";
                case AntigateError.IP_NOT_ALLOWED:
                    return "IP not allowed";
                case AntigateError.WRONG_ID_FORMAT:
                    return "Wrong captcha ID";
                case AntigateError.CAPTCHA_UNSOLVABLE:
                    return "Captcha unsolvable";
                default:
                    return string.Empty;
            }
        }
    }
}