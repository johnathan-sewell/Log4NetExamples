using System;
using log4net;

namespace Log4NetExamples.ConsoleApplication1
{
	class Looper
	{
		private readonly ILog _logger;

		public Looper()
		{
			//get the logger for this type
			_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
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
