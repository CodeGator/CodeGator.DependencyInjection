
#pragma warning disable IDE0130
namespace System;
#pragma warning restore IDE0130

/// <summary>
/// This class provides global access to a service provider.
/// </summary>
public sealed class ServiceLocator : IServiceProvider
{
    // *******************************************************************
    // Fields.
    // *******************************************************************

    #region Fields

    /// <summary>
    /// This field contains the inner service provider for this class.
    /// </summary>
    internal static IServiceProvider? _innerServiceProvider = null;

    /// <summary>
    /// This field contains the singleton instance of this class.
    /// </summary>
    private static ServiceLocator? _instance = null;

    #endregion

    // *******************************************************************
    // Constructors.
    // *******************************************************************

    #region Constructors

    /// <summary>
    /// This constructor creates a new instance of the <see cref="ServiceLocator"/>
    /// class.
    /// </summary>
    private ServiceLocator() { }

    #endregion

    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method returns the singleton instance of this class.
    /// </summary>
    /// <returns>The singleton instance of this class.</returns>
    public static ServiceLocator Instance()
    {
        if (_instance is null)
        {
            _instance = new ServiceLocator();
        }
        return _instance;
    }

    // *******************************************************************

    /// <inheritdoc/>
    public object? GetService(Type serviceType)
    {
        return _innerServiceProvider?.GetService(serviceType);
    }

    #endregion
}
