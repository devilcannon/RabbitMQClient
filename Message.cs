
using Newtonsoft.Json;

namespace RabbitMQClient
{
    public class Message
    {
        public enum TestResult
        {
            Passed = 0,
            Failed = 1,
            Error = 2,
            Terminated = 3
        }

        public string? MessageCode { get; set; }
        public int TestSocket { get; set; }
        public string? UnitId { get; set; }
        public string? SerialNumber { get; set; }
        public TestDefinition? TestDefinition { get; set; }
        public TestResult Result { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public string? Sender { get; set; }
        public DateTime Timestamp { get; set; }

        public static string GetNewUnitMessage()
        {
            return JsonConvert.SerializeObject(new Message { MessageCode="NextUnit",TestSocket=0,Sender="PCSPIDER"+GetRandomId(),Timestamp = DateTime.Now});
        }

        public static string GetUnitIdentied()
        {
            return JsonConvert.SerializeObject(new Message { MessageCode = "ScanUnit", TestSocket = 0, UnitId="00A00"+GetRandomId(),Sender = "PCSPIDER" + GetRandomId(), Timestamp = DateTime.Now });
        }

        public static string GetPassed()
        {
            return JsonConvert.SerializeObject(new Message { MessageCode = "TestDone", TestSocket = 0, 
                UnitId = "00A00" + GetRandomId(),
                SerialNumber = "2523JBM0"+GetRandomId(),
                TestDefinition = new TestDefinition{ ProductPartNumber = "9999-01-99", ProductLevel = "PU", TestName = "" },
                Result = TestResult.Passed,
                Sender = "PCSPIDER" + GetRandomId(), 
                Timestamp = DateTime.Now });
        }

        public static string GetFailed()
        {
            return JsonConvert.SerializeObject(new Message
            {
                MessageCode = "TestDone",
                TestSocket = 0,
                UnitId = "00A00" + GetRandomId(),
                SerialNumber = "",
                TestDefinition = new TestDefinition { ProductPartNumber = "9999-01-99", ProductLevel = "UA", TestName = "" },
                Result = TestResult.Failed,
                ErrorCode = "Step that failed",
                ErrorMessage = "Measurement 0",
                Sender = "PCSPIDER" + GetRandomId(),
                Timestamp = DateTime.Now
            });
        }

        public static string GetUnitWithError()
        {
            return JsonConvert.SerializeObject(new Message
            {
                MessageCode = "TestDone",
                TestSocket = 0,
                UnitId = "00A00" + GetRandomId(),
                SerialNumber = "",
                TestDefinition = new TestDefinition  { ProductPartNumber = "9999-01-99", ProductLevel = "SA", TestName = "" },
                Result = TestResult.Failed,
                ErrorCode = "Step causing error",
                ErrorMessage = "Error code 123",
                Sender = "PCSPIDER" + GetRandomId(),
                Timestamp = DateTime.Now
            });
        }

        public static int GetRandomId()
        {
            Random rnd = new Random();
            return rnd.Next(1, 998 + 1);
        }

    }
    public class TestDefinition
    {
        public string? ProductPartNumber { get; set; }
        public string? ProductLevel { get; set; }
        public string? TestName { get; set; }
    }
}
