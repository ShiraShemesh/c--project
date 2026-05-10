namespace BlApi;

using BlImplementation;
using DalApi;

public static class Factory
{
    public static IBL Get()
    {
        return new BlImplementation.BL();
    }
}
