namespace CloneStateBehavior_;

using static CounterState;
using static CloneTestState;
public class Should : BaseTest
{
  private CloneTestState CloneTestState => Store.GetState<CloneTestState>();
  private CounterState CounterState => Store.GetState<CounterState>();
  private ApplicationState ApplicationState => Store.GetState<ApplicationState>();

  public Should(ClientHost aWebAssemblyHost) : base(aWebAssemblyHost) { }

  public async Task CloneState()
  {
    //Arrange
    CounterState.Initialize(aCount: 15);
    Guid preActionGuid = CounterState.Guid;

    // Create request
    var incrementCounterRequest = new IncrementCounterAction
    {
      Amount = -2
    };
    //Act
    await Send(incrementCounterRequest);

    //Assert
    CounterState.Guid.Should().NotBe(preActionGuid);
  }

  public async Task CloneStateUsingOverridenClone()
  {
    //Arrange
    CloneTestState.Initialize(aCount: 15);
    Guid preActionGuid = CloneTestState.Guid;

    var cloneTestAction = new CloneTestAction { };
    //Act
    await Send(cloneTestAction);

    //Assert
    CloneTestState.Guid.Should().NotBe(preActionGuid);
    CloneTestState.Count.Should().Be(42);
  }

  public async Task RollBackStateAndPublish_When_Exception()
  {
    // Arrange
    // Setup know state.
    CounterState.Initialize(aCount: 22);
    ApplicationState.Initialize("anyname", "");
    Guid preActionGuid = CounterState.Guid;

    var throwExceptionAction = new ThrowExceptionAction
    {
      Message = "Test Rollback of State"
    };

    // Act
    await Send(throwExceptionAction);

    // Assert
    ApplicationState.ExceptionMessage.Should().Be(throwExceptionAction.Message);
    CounterState.Guid.Equals(preActionGuid).Should().BeTrue();
  }
}
