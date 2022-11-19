using System.Text;

namespace Lab3.Hash
{
    public class HashFunction
    {
        private readonly byte _resultSize;

        private string? _hashString = null;

        public HashFunction(byte resultSize)
        {
            _resultSize = resultSize;
        }

        // TODO: реализовать хеш-функцию. Возвращает строку битов (примеры: "01", "0101", "10101010")
        public string Calculate(byte[] message)
        {
            var stringBuilder = new StringBuilder();


            _hashString = stringBuilder.ToString();

            return _hashString;
        }

        // TODO: реализовать подсчет процента уникальности хеш-строки при изменении любого байта
        public void CheckMixing(byte[] message)
        {

        }
    }
}
