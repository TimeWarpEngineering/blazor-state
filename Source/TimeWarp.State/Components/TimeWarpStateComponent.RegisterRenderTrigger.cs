namespace TimeWarp.State;

public partial class TimeWarpStateComponent
{
  private readonly ConcurrentDictionary<Type, Func<bool>> RenderTriggers = new();
  private readonly ConcurrentDictionary<(Type StateType, string PropertyName), Func<object, object, bool>> CompiledPropertyComparisons = new();
  
  /// <summary>
  /// Set this to true if something in the component has changed that requires a re-render.
  /// </summary>
  protected bool NeedsRerender;

  /// <inheritdoc />
  protected override bool ShouldRender()
  {
    // If there are no RenderTriggers, default to true (standard Blazor behavior)
    if (RenderTriggers.Count == 0)
      return true;

    // If there are RenderTriggers, use NeedsRerender flag
    bool result = NeedsRerender;
    NeedsRerender = false;
    return result;
  }

  /// <inheritdoc />
  public virtual bool ShouldReRender(Type stateType)
  {
    ArgumentNullException.ThrowIfNull(stateType);

    NeedsRerender = RenderTriggers.TryGetValue(stateType, out Func<bool>? check) && check();
    return NeedsRerender;
  }
  
  /// <summary>
  /// Determines whether the component should re-render based on changes in a specific state type.
  /// </summary>
  /// <typeparam name="T">The type of state to check.</typeparam>
  /// <param name="stateType">The type of state that has changed.</param>
  /// <param name="condition">A function that evaluates given the previous state and returns true if a re-render is needed.</param>
  /// <returns>True if the component should re-render; otherwise, false.</returns>
  /// <remarks>
  /// This method checks if the changed state type matches the generic type parameter T.
  /// If it matches, it retrieves the previous state and applies the provided condition.
  /// The component will re-render if the condition returns true given the previous state.
  /// </remarks>
  protected bool ShouldReRender<T>(Type stateType, Func<T, bool> condition) where T : class
  {
    if (stateType != typeof(T)) return false;
    T? previousState = GetPreviousState<T>();
    if (previousState == null) return true;
    bool result = condition(previousState);
    Logger.LogDebug(EventIds.TimeWarpStateComponent_ShouldReRender, "ShouldReRender ComponentType: {ComponentId} StateType: {StateType} Result: {Result}", Id, stateType.FullName, result);

    return result;
  }
  /// <summary>
  /// Registers a render trigger for a specific state type.
  /// </summary>
  /// <typeparam name="T">The type of state to check. Must be a reference type.</typeparam>
  /// <param name="triggerCondition">A function that takes the previous state of type T and returns a boolean indicating whether a re-render is needed.</param>
  /// <remarks>
  /// This method adds a new entry to the RenderTriggers dictionary. The key is the Type of T, 
  /// and the value is a function that will be called to determine if a re-render is necessary 
  /// when the state of type T changes. The function should compare the previous state 
  /// (passed as an argument) with the current state (which should be accessible within the component).
  /// </remarks>
  /// <example>
  /// <code>
  /// RegisterRenderTrigger&lt;UserState&gt;(previousUserState => UserState.Name != previousUserState.Name);
  /// </code>
  /// </example>
  protected void RegisterRenderTriggerCondition<T>(Func<T, bool> triggerCondition) where T : class
  {
    RenderTriggers[typeof(T)] = () => ShouldReRender(typeof(T), triggerCondition);
  }
  protected void RegisterRenderTrigger<T>(Expression<Func<T, object?>> propertySelector) where T : class
  {
    ArgumentNullException.ThrowIfNull(propertySelector);
    
    Func<T, T, bool> comparisonFunc = CreateComparisonFunc(propertySelector);
    
    RenderTriggers[typeof(T)] = () =>
    {
      T? previousState = GetPreviousState<T>();
      T currentState = GetState<T>(false);
      return previousState == null || comparisonFunc(previousState, currentState);
    };
  }

  private static Func<T, T, bool> CreateComparisonFunc<T>(Expression<Func<T, object?>> propertySelector) where T : class
  {
    Func<T, object?> compiledSelector = propertySelector.Compile();
    
    return (T previous, T current) =>
    {
      object? previousValue = compiledSelector(previous);
      object? currentValue = compiledSelector(current);
        
      return !Equals(previousValue, currentValue);
    };
  }

  private string GetPropertyPath<T>(Expression<Func<T, object?>> propertySelector)
  {
    if (propertySelector.Body is MemberExpression memberExpression)
    {
      return GetMemberExpressionPath(memberExpression);
    }
    else if (propertySelector.Body is UnaryExpression unaryExpression)
    {
      if (unaryExpression.Operand is MemberExpression memberExpr)
      {
        return GetMemberExpressionPath(memberExpr);
      }
    }
    throw new ArgumentException("Invalid property selector", nameof(propertySelector));
  }

// ... other methods remain the same
  private string GetMemberExpressionPath(MemberExpression? expression)
  {
    var path = new List<string>();
    while (expression != null)
    {
      path.Add(expression.Member.Name);
      expression = expression.Expression as MemberExpression;
    }
    path.Reverse();
    return string.Join(".", path);
  }

  private object? GetPropertyValue(object? obj, string propertyPath)// Add '?' to 'object?'
  {
    if (obj == null) return null;// Add null check at the beginning

    string[] properties = propertyPath.Split('.');
    object? value = obj;
    foreach (string property in properties)
    {
      if (value == null) return null;
      PropertyInfo? propertyInfo = value.GetType().GetProperty(property);
      if (propertyInfo == null) return null;
      value = propertyInfo.GetValue(value);
    }
    return value;
  }
}
