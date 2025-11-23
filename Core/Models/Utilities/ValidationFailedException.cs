namespace Core.Models.Utilities
{
    /// <summary>
    ///     Exception to be thrown when the validation has failed, specifically
    ///     from any method which uses the <see cref="ValidateModel"/> object
    ///     to represent whether or not the object was validated properly.
    /// </summary>
    public class ValidationFailedException : ArgumentException
    {
        public ValidationFailedException() : base()
        {

        }

        public ValidationFailedException(string msg) : base(msg)
        {

        }

        public ValidationFailedException(List<string> errMsgs) : base(FormatListOfErrors(errMsgs))
        {
        }

        /// <summary>
        ///     Formats a list of error messages into a singular string to be 
        ///     passed into the base constructor.
        /// </summary>
        /// <param name="errMsgs"></param>
        /// <returns></returns>
        private static string FormatListOfErrors(List<string> errMsgs)
        {
            string errMsg = string.Empty;
            foreach (var msg in errMsgs)
            {
                errMsg += $"{msg} | ";
            }

            return errMsg;
        }
    }
}
