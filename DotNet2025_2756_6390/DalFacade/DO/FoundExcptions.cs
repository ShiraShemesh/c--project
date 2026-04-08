namespace DO;

public class IdNotFoundExcptions : Exception
{
    public IdNotFoundExcptions(String messege) : base(messege)
    {
    }
}
public class IdExisteFoundExcptions : Exception
{
    public IdExisteFoundExcptions(String message) : base(message)
    {
    }
}

