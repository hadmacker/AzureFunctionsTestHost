namespace FunctionApp1
{
    public class NameServiceImpl : INameService
    {
        public string Message(string name)
        {
            return $"Hello, {name}. This HTTP triggered function executed successfully.";
        }
    }
}