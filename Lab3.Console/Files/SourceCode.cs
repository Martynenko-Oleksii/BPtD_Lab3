namespace Lab3.Console.Files
{
    public class SourceCode
    {
        private readonly string _var;

        public SourceCode(string var)
        {
            _var = var;
        }

        public void Func()
        {
            System.Console.WriteLine(_var);
        }
    }
}
