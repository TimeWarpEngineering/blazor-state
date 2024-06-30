namespace TimeWarp.State;

using System.Text.Json.Serialization;

public abstract class State<TState> : IState<TState>
{

  #region JsonIgnore
  // JsonIgnore is used to prevent serialization of the property by both AnyClone and ReduxDevTools 
  
  [JsonIgnore]
  public ISender Sender { get; set; } = null!;
  
  #endregion

  #region IgnoreDataMember

  // IgnoreDataMember is used to prevent serialization of properties by AnyClone
  // They change on every instance creation and are not needed for cloning
  
  [IgnoreDataMember]
  public Guid Guid { get; protected init; } = Guid.NewGuid();
  #endregion
  
  public string? CacheKey { get; protected init; }
  public DateTime? TimeStamp { get; protected init; }
  public TimeSpan CacheDuration { get; protected init;}

  /// <summary>
  /// DI Constructor
  /// </summary>
  /// <param name="sender"></param>
  protected State(ISender sender) 
  {
    Sender = sender;
  }
  
  [JsonConstructor]
  protected State() {}


  /// <summary>
  /// returns a new instance of type TState
  /// </summary>
  /// <param name="keyValuePairs">Initialize the TState instance with these values</param>
  /// <returns>The particular State of type TState</returns>
  /// <remarks>Implement this if you want to use ReduxDevTools Time Travel</remarks>
  public virtual TState Hydrate(IDictionary<string, object> keyValuePairs) => throw new NotImplementedException();

  /// <summary>
  /// Use this method to prevent running methods from source other than Tests
  /// </summary>
  /// <param name="assembly"></param>
  protected void ThrowIfNotTestAssembly(Assembly assembly)
  {
    ArgumentNullException.ThrowIfNull(assembly);
    ArgumentNullException.ThrowIfNull(assembly.FullName);
    
    if (!assembly.FullName.Contains("Test"))
    {
      throw new FieldAccessException("Do not use this in production. This method is intended for Test access only!");
    }
  }
  
  /// <summary>
  /// Checks if the cache is valid based on the current cache key and timestamp
  /// </summary>
  /// <param name="currentCacheKey">The cache key to validate against</param>
  /// <returns>True if the cache is valid, otherwise false</returns>
  public bool IsCacheValid(string currentCacheKey) => 
    CacheKey == currentCacheKey &&
    TimeStamp.HasValue &&
    (DateTime.UtcNow - TimeStamp.Value) < CacheDuration;

  /// <summary>
  /// Override this to Set the initial state
  /// </summary>
  public abstract void Initialize();
}
