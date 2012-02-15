
using System;

//see http://logging.apache.org/log4net/release/manual/configuration.html#attributes
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Log4NetExamples.ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{
			//get the logger for this type
			var logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

			//get the logger by name
			var emailLogger = log4net.LogManager.GetLogger("EmailLogger");


			//simulate some activity and an exception
			try
			{
				var looper = new Looper();
				looper.Loop();
			}
			catch (Exception ex)
			{
				emailLogger.Error("Help, something went wrong ... " + ex.Message);
				logger.Error(ex.Message);
			}
		}
	}
}
