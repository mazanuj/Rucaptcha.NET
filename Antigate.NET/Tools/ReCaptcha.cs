using System;
using System.Text.RegularExpressions;

namespace Akumu.Antigate.Tools
{
    /// <summary>
    /// Статический класс с набором инструментов для упрощения работы с ReCaptcha
    /// 
    /// </summary>
    public static class ReCaptcha
    {
        private static readonly Regex ReCapChallenge = new Regex("challenge(?:\\s+)?:(?:\\s+)?'([a-zA-Z0-9_-]+)',");

        private static readonly Regex ReCapChallengeLink =
            new Regex("(http://(?:www.)?google.com/recaptcha/api/challenge\\?k=(?:\\w+))");

        /// <summary>
        /// Функция возвращает string массив с ссылками на JS скрипты всех капч на странице. Контент этих страниц можно передавать функции ReCaptcha.GetObject(string)
        /// 
        /// </summary>
        /// <param name="PageContent">Контент веб страницы для поиска</param>
        /// <returns>
        /// string массив с ссылками на JS скрипты всех капч на странице. null если капч не найдено.
        /// </returns>
        public static string[] GetObjectsUrlsOnPage(string PageContent)
        {
            if (string.IsNullOrEmpty(PageContent))
                throw new ArgumentException("Page content is empy or null");
            var matchCollection = ReCapChallengeLink.Matches(PageContent);
            if (matchCollection.Count <= 0)
                return null;
            var strArray = new string[matchCollection.Count];
            var index = 0;
            foreach (Match match in matchCollection)
            {
                strArray[index] = match.Groups[1].Value;
                ++index;
            }
            return strArray;
        }

        /// <summary>
        /// Функция возвращает объект ReCaptchaObject, содержащий в себе URL изображения капчи и recaptcha_challenge_field.
        /// 
        /// </summary>
        /// <param name="ScriptPage">Контент страницы challenge скрипта (i.e. http://api.recaptcha.net/challenge?k=6LfuVAYAAAAAAIDSp_7YKyuUU5f7SwfiDDwlUI4l )</param>
        /// <returns>
        /// Функция возвращает URL изображения капчи, null если не найдено
        /// </returns>
        public static ReCaptchaObject GetObject(string ScriptPage)
        {
            if (string.IsNullOrEmpty(ScriptPage))
                throw new ArgumentException("Script page content is empy or null");
            var match = ReCapChallenge.Match(ScriptPage);
            return match.Success ? new ReCaptchaObject(match.Groups[1].Value) : null;
        }
    }
}