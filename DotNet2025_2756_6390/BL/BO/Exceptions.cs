namespace BO;

[Serializable]
public class BlIdNotExistException : Exception
{
    public BlIdNotExistException(string? message) : base(message) { }
    public BlIdNotExistException(string message, Exception innerException)
        : base(message, innerException) { }
}

[Serializable]
public class BlIdAlreadyExistException : Exception
{
    public BlIdAlreadyExistException(string? message) : base(message) { }
    public BlIdAlreadyExistException(string message, Exception innerException)
        : base(message, innerException) { }
}

[Serializable]
public class BlInvalidInputException : Exception
{
    public BlInvalidInputException(string? message) : base(message) { }
    public BlInvalidInputException(string message, Exception innerException)
        : base(message, innerException) { }
}

[Serializable]
public class BlInsufficientStockException : Exception
{
    public BlInsufficientStockException(string? message) : base(message) { }
    public BlInsufficientStockException(string message, Exception innerException)
        : base(message, innerException) { }
}

[Serializable]
public class BlInvalidQuantityException : Exception
{
    public BlInvalidQuantityException(string? message) : base(message) { }
    public BlInvalidQuantityException(string message, Exception innerException)
        : base(message, innerException) { }
}