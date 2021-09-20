using System;
using DemoLibrary.Utilities;

namespace DemoLibrary
{
    public class BetterBusinessLogic : IBusinessLogic
    {
        private readonly ILogger _logger;
        private readonly IDataAccess _dataAccess;
        
        // Here we can pass fake logger and dataAccess instead of real logger and database to test the code.
        // But If we would instantiate inside the class then we could not simulate fake logger and dataAccess
        public BetterBusinessLogic(ILogger logger, IDataAccess dataAccess)
        {
            _logger = logger;
            _dataAccess = dataAccess;
        }
        
        public void ProcessData()
        {
            Console.WriteLine("--BETTER BUSINESS LOGIC--");
            _logger.log("Starting the processing of data");
            Console.WriteLine("Processing the data");
            _dataAccess.LoadData();
            _dataAccess.SaveData("ProcessedInfo");
            _logger.log("Finished processing of the data");
            Console.WriteLine("--BETTER BUSINESS LOGIC--");
        }
    }
}