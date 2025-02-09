﻿using degree_management.constracts.Exceptions.Validations;

namespace degree_management.constracts.Responses.Result;

public class ResultT<TValue> : Result
{
    private readonly TValue? _value;

    protected internal ResultT(TValue? value,bool isSuccess, Error error) : base(isSuccess, error)
        => _value = value;
    public TValue Value => IsSuccess ? _value! : throw new InvalidOperationException("The value of a failure result can not be accessed");

    public static implicit operator ResultT<TValue>(TValue value) => Create(value);
}