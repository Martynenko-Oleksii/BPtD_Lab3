namespace Lab3.Console
{
    public static class MessageReader
    {
        public static async Task<byte[]> ReadBytes(string path)
        {
            return await File.ReadAllBytesAsync(path);
        }
    }
}
