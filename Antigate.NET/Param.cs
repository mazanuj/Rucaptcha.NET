namespace Akumu.Antigate
{
    /// <summary>
    /// Объект дополнительного параметра API запроса
    /// 
    /// </summary>
    public class Param
    {
        /// <summary>
        /// Ключ
        /// 
        /// </summary>
        public string Key;

        /// <summary>
        /// Значение
        /// 
        /// </summary>
        public string Value;

        /// <summary>
        /// Новый объект параметра для API запросов
        /// 
        /// </summary>
        /// <param name="Key">Ключ</param><param name="Value">Значение</param>
        public Param(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }
}