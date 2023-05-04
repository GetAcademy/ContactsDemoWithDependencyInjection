namespace ContactsDemoWithDependencyInjection
{
    public class MyService : IService
    {
        public MyService()
        {
            Console.WriteLine("ctor MyService");
        }

        public void DoSomething()
        {
            Console.WriteLine("DoSomething");
        }
    }
}
