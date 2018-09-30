﻿using System;


namespace YiyilookGhtk.Classes
{
    class Result<T> : IResult<T>
    {
        public bool Succeeded { get; }
        public T Value { get; }
        public ResultInfo Info { get; }

        public Result(bool succeeded, T value, ResultInfo info)
        {
            Succeeded = succeeded;
            Value = value;
            Info = info;
        }

        public Result(bool succeeded, ResultInfo info)
        {
            Succeeded = succeeded;
            Info = info;
        }

        public Result(bool succeeded, T value)
        {
            Succeeded = succeeded;
            Value = value;
        }

        
    }

    public static class Result
    {
        public static IResult<T> Success<T>(T resValue)
        {
            return new Result<T>(true, resValue, new ResultInfo("No errors detected"));
        }

        public static IResult<T> Success<T>(string successMsg, T resValue)
        {
            return new Result<T>(true, resValue, new ResultInfo(successMsg));
        }

        public static IResult<T> Fail<T>(Exception exception)
        {
            return new Result<T>(false, default(T), new ResultInfo(exception));
        }

        public static IResult<T> Fail<T>(string errMsg)
        {
            return new Result<T>(false, default(T), new ResultInfo(errMsg));
        }

        public static IResult<T> Fail<T>(string errMsg, T resValue)
        {
            return new Result<T>(false, resValue, new ResultInfo(errMsg));
        }

        public static IResult<T> Fail<T>(Exception exception, T resValue)
        {
            return new Result<T>(false, resValue, new ResultInfo(exception));
        }

        public static IResult<T> Fail<T>(ResultInfo info, T resValue)
        {
            return new Result<T>(false, resValue, info);
        }

    }
}
