

namespace Infrastructure.Crosscutting.SeedWork.Ioc
{
    /// <summary>
    /// Ioc Factory
    /// </summary>
    public static class IocFactory
    {
        #region Members
        static IIocFactory _currentIocFactory = null;
        #endregion

        #region Public Methods

        /// <summary>
        /// Set the  Ioc factory to use
        /// </summary>
        /// <param name="logFactory">Log factory to use</param>
        public static void SetCurrent(IIocFactory logFactory)
        {
            _currentIocFactory = logFactory;
        }

        /// <summary>
        /// Createt a new <paramref name="Infrastructure.Crosscutting.SeedWork.Ioc"/>
        /// </summary>
        /// <returns>Created ILog</returns>
        public static IInstanceLocator CreateIoc()
        {
            return (_currentIocFactory != null) ? _currentIocFactory.Create() : null;
        }

        #endregion
    }
}
