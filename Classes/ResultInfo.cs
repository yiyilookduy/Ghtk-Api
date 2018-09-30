using System;


namespace YiyilookGhtk.Classes
{
    public class ResultInfo
    {
        public ResultInfo(string message)
        {
            Message = message;
        }

        public ResultInfo(Exception exception)
        {
            Exception = exception;
            Message = exception?.Message;
        }

        public Exception Exception { get; }

        public string Message { get; }

    }
}
