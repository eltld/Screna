using System;

namespace Screna.Audio
{
    /// <summary>
    /// Summary description for MmException.
    /// </summary>
    class MmException : Exception
    {
        /// <summary>
        /// Creates a new MmException
        /// </summary>
        /// <param name="result">The result returned by the Windows API call</param>
        /// <param name="function">The name of the Windows API that failed</param>
        public MmException(MmResult result, string function)
            : base(ErrorMessage(result, function)) { }

        static string ErrorMessage(MmResult result, string function)
        {
            return $"{result} calling {function}";
        }

        /// <summary>
        /// Helper function to automatically raise an exception on failure
        /// </summary>
        /// <param name="result">The result of the API call</param>
        /// <param name="function">The API function name</param>
        public static void Try(MmResult result, string function)
        {
            if (result != MmResult.NoError)
                throw new MmException(result, function);
        }
    }
}