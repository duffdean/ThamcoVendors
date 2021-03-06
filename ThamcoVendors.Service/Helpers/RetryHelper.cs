﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThamcoVendors.Service.Helpers
{
    public static class RetryHelper
    {
        //I am using log4net but swap in your favourite
        //private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static async Task RetryOnExceptionAsync(
            int times, TimeSpan delay, Func<Task> operation)
        {
            await RetryOnExceptionAsync<Exception>(times, delay, operation);
        }

        public static async Task RetryOnExceptionAsync<TException>(
            int times, TimeSpan delay, Func<Task> operation) where TException : Exception
        {
            if (times <= 0)
                throw new ArgumentOutOfRangeException(nameof(times));

            var attempts = 0;
            do
            {
                try
                {
                    attempts++;
                    try
                    {
                        await operation();
                    }
                    catch (Exception ex)
                    {
                        if (attempts == times)
                            throw;

                        await CreateDelayForException(times, attempts, delay, ex);

                    }
                    
                    break;
                }
                catch (TException ex)
                {
                    if (attempts == times)
                        throw;

                    await CreateDelayForException(times, attempts, delay, ex);
                }
            } while (true);
        }

        private static Task CreateDelayForException(
            int times, int attempts, TimeSpan delay, Exception ex)
        {
            //Log.Warn($"Exception on attempt {attempts} of {times}. " +
           //           "Will retry after sleeping for {delay}.", ex);
            return Task.Delay(IncreasingDelayInSeconds(attempts));
        }

        internal static int[] DelayPerAttemptInSeconds =
        {
            (int) TimeSpan.FromSeconds(2).TotalSeconds,
            (int) TimeSpan.FromSeconds(30).TotalSeconds,
            (int) TimeSpan.FromMinutes(2).TotalSeconds,
            (int) TimeSpan.FromMinutes(10).TotalSeconds,
            (int) TimeSpan.FromMinutes(30).TotalSeconds
        };

        static int IncreasingDelayInSeconds(int failedAttempts)
        {
            if (failedAttempts <= 0) throw new ArgumentOutOfRangeException();

            return failedAttempts > DelayPerAttemptInSeconds.Length ? DelayPerAttemptInSeconds.Last() : DelayPerAttemptInSeconds[failedAttempts];
        }
    }
}
