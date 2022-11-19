using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Hash
{
    public static class CollisionFinder
    {
        public static List<byte[]> GetMessages(HashFunction function, byte[] message)
        {
            var messages = new List<byte[]>();
            var originalHashString = function.Calculate(message);

            byte[] updatedMessage = new byte[message.Length + 1];
            message.CopyTo(updatedMessage, 0);

            for (int i = 0; i <= byte.MaxValue; i++)
            {
                var hashCode = Convert.ToByte(originalHashString, 2);
                updatedMessage[updatedMessage.Length - 1] = (byte)(hashCode ^ i);

                if (function.Calculate(updatedMessage).Equals(originalHashString))
                {
                    byte[] messageWithSameHash = new byte[updatedMessage.Length];
                    updatedMessage.CopyTo(messageWithSameHash, 0);
                    messages.Add(messageWithSameHash);
                }
            }

            return messages;
        }
    }
}
