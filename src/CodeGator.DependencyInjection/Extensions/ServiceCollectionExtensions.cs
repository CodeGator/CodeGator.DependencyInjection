
namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
/// This class utility contains extension methods related to the <see cref="IServiceCollection"/>
/// type.
/// </summary>
public static partial class ServiceCollectionExtensions
{
    // *******************************************************************
    // Public methods.
    // *******************************************************************

    #region Public methods

    /// <summary>
    /// This method gets an options builder that forwards Configure calls for 
    /// the same <typeparamref name="TOptions"/> to the underlying service 
    /// collection. When called more than once, this method collapses to a
    /// no-op.
    /// </summary>
    /// <typeparam name="TOptions">The options type to be configured.</typeparam>
    /// <param name="serviceCollection">The service collection to use for 
    /// the operation.</param>
    /// <param name="name">The options name to use for the operation.</param>
    /// <returns>An <see cref="OptionsBuilder{TOptions}"/>.</returns>
    public static OptionsBuilder<TOptions> TryAddOptions<TOptions>(
        [NotNull] this IServiceCollection serviceCollection,
        [AllowNull] string? name = null
        ) where TOptions : class
    {
        Guard.Instance().ThrowIfNull(serviceCollection, nameof(serviceCollection));

        var serviceDescriptor = new ServiceDescriptor(
            serviceType: typeof(TOptions),
            implementationType: typeof(TOptions),
            lifetime: ServiceLifetime.Scoped
            );

        if (serviceCollection.Contains(serviceDescriptor))
        {
            return new OptionsBuilder<TOptions>(
                serviceCollection,
                name
                );
        }

        var optionsBuilder = serviceCollection.AddOptions<TOptions>();
        return optionsBuilder;
    }

    #endregion
}
