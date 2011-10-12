

namespace Infrastructure.Crosscutting.SeedWork.Ioc
{
    /// <summary>
    /// Base contract for Log abstract factory
    /// </summary>
    public interface IIocFactory
    {
        /// <summary>
        /// Create a new ILog
        /// </summary>
        /// <returns>The ILog created</returns>
        IInstanceLocator Create();
    }
}
