using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StudentScheduler.Share.Abstractions
{
	public class Result
	{
		public bool IsSuccess { get; private set; }
		public bool IsFailure => !IsSuccess;


		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
		public Error Error { get; protected set; }
		protected Result()
		{
			IsSuccess = true;
			Error = Error.Empty;
		}

		protected Result(Error error)
		{
			IsSuccess = false;
			Error = error;
		}

		public static implicit operator Result(Error error) =>
			new(error);

		public static Result Success() =>
			new();

		public static Result Failure(Error error) =>
			new(error);
	}

	public sealed class ResultValue<TValue> : Result
	{
		private readonly TValue? _value;

		private ResultValue(
			TValue value
		) : base()
		{
			_value = value;
		}

		private ResultValue(
			Error error
		) : base(error)
		{
			_value = default;
		}

		public TValue Value =>
			IsSuccess ? _value! : throw new InvalidOperationException("Value can not be accessed when IsSuccess is false");

		public static implicit operator ResultValue<TValue>(Error error) =>
			new(error);

		public static implicit operator ResultValue<TValue>(TValue value) =>
			new(value);

		public static ResultValue<TValue> Success(TValue value) =>
			new(value);

		public static new ResultValue<TValue> Failure(Error error) =>
			new(error);
	}
}
