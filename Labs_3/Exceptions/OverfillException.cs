﻿namespace Labs_3.Exceptions;

public class OverfillException : Exception
{
    public OverfillException() {}
    public OverfillException(string message) : base(message) {}
}