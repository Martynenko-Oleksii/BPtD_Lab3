using System.Text;

namespace Lab3.Hash
{
    public class HashFunction
    {
        private static byte[] Sbox8 = {
        98,  6, 85,150, 36, 23,112,164,135,207,169,  5, 26, 64,165,219,
        61, 20, 68, 89,130, 63, 52,102, 24,229,132,245, 80,216,195,115, 
        90,168,156,203,177,120,  2,190,188,  7,100,185,174,243,162, 10, 
        237, 18,253,225,  8,208,172,244,255,126,101, 79,145,235,228,121, 
        123,251, 67,250,161,  0,107, 97,241,111,181, 82,249, 33, 69, 55, 
        59,153, 29,  9,213,167, 84, 93, 30, 46, 94, 75,151,114, 73,222, 
        197, 96,210, 45, 16,227,248,202, 51,152,252,125, 81,206,215,186, 
        39,158,178,187,131,136,  1, 49, 50, 17,141, 91, 47,129, 60, 99, 
        154, 35, 86,171,105, 34, 38,200,147, 58, 77,118,173,246, 76,254, 
        133,232,196,144,198,124, 53,  4,108, 74,223,234,134,230,157,139, 
        189,205,199,128,176, 19,211,236,127,192,231, 70,233, 88,146, 44, 
        183,201, 22, 83, 13,214,116,109,159, 32, 95,226,140,220, 57, 12, 
        221, 31,209,182,143, 92,149,184,148, 62,113, 65, 37, 27,106,166, 
        3, 14,204, 72, 21, 41, 56, 66, 28,193, 40,217, 25, 54,179,117, 
        238, 87,240,155,180,170,242,212,191,163, 78,218,137,194,175,110, 
        43,119,224, 71,122,142, 42,160,104, 48,247,103, 15, 11,138,239  
        };

        private static byte[] Sbox4 = {12,2,13,3,6,15,1,5,14,9,0,10,8,4,11,7};

        private static byte[] Sbox2 = { 1, 3, 0, 2 };

        private readonly byte _resultSize;

        public HashFunction(byte resultSize)
        {
            _resultSize = resultSize;
        }

        public string Calculate(byte[] message)
        {
            var stringBuilder = new StringBuilder();

            byte hash = 0;

            byte[] Sbox = {};

            switch (_resultSize)
            {
                case 2:
                    Sbox = Sbox2;
                    break;
                case 4:
                    Sbox = Sbox4;
                    break;
                case 8:
                    Sbox = Sbox8;
                    break;
            }

            foreach (var m in message)
            {
                hash = Sbox[(byte)(hash ^ m) % Sbox.Length];
            }

            return Convert.ToString(hash, 2).PadLeft(_resultSize, '0');
        }

        public double CheckMixing(byte[] message)
        {
            var hashString = Calculate(message);

            double percent = 0;
            byte[] updatedmessage = new byte[message.Length];
            message.CopyTo(updatedmessage, 0);

            var loopsCount = 10000 > message.Length ? message.Length : 10000;
            var random = new Random();
            for (int i = 0; i < loopsCount; i++)
            {
                updatedmessage[i] += (byte)random.NextInt64(0, 256);

                var newHashString = Calculate(updatedmessage);
                double uniqueBitsCount = 0;
                for (int j = 0; j < hashString.Length; j++)
                {
                    uniqueBitsCount += (hashString[j] != newHashString[j] ? 1 : 0);
                }
                var stagePercet = Math.Round((uniqueBitsCount / hashString.Length * 100), 1);

                //Console.WriteLine($"Unique bits: {stagePercet}%");

                percent += stagePercet;
                updatedmessage[i] = message[i];
            }

            return Math.Round(percent / loopsCount, 1);
        }
    }
}
