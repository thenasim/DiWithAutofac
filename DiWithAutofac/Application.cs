using DemoLibrary;

namespace DiWithAutofac
{
    public class Application : IApplication
    {
        private readonly IBusinessLogic _businessLogic;
        
        public Application(IBusinessLogic businessLogic)
        {
            _businessLogic = businessLogic;
        }

        public void Run()
        {
            _businessLogic.ProcessData();
        }
    }
}