using System;
using System.Reflection;
using log4net;
using log4net.Config;

//see http://logging.apache.org/log4net/release/manual/configuration.html#attributes
[assembly: XmlConfigurator(Watch = true)]
namespace Log4NetExamples.ConsoleApplication1
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			//get the logger for this type
			var logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

			//get the logger by name
			var emailLogger = LogManager.GetLogger("EmailLogger");


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

	internal class Looper
	{
		private readonly ILog _logger;

		public Looper()
		{
			//get the logger for this type
			_logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
		}

		public void Loop()
		{
			_logger.Info("Running the loop");

			for (int i = 0; i < 10; i++)
			{
				if (i == 7)
					throw new ApplicationException("I don't like sevens");

				_logger.Info("Loop body " + i);
			}
		}
	}
}