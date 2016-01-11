namespace Akumu.Antigate
{
    public enum AntigateError
    {
        WRONG_USER_KEY,
        KEY_DOES_NOT_EXIST,
        ZERO_BALANCE,
        ZERO_CAPTCHA_FILESIZE,
        TOO_BIG_CAPTCHA_FILESIZE,
        WRONG_FILE_EXTENSION,
        IMAGE_TYPE_NOT_SUPPORTED,
        IP_NOT_ALLOWED,
        WRONG_ID_FORMAT,
        CAPTCHA_UNSOLVABLE
    }
}