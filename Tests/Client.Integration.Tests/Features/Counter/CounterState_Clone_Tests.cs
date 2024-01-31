namespace CounterState_;

public class Clone_Should : BaseTest
{
  public Clone_Should(ClientHost aWebAssemblyHost) : base(aWebAssemblyHost)
  {
    CounterState = Store.GetState<CounterState>();
  }

  private CounterState CounterState { get; set; }

  public void Clone()
  {
    //Arrange
    CounterState.Initialize(aCount: 15);

    //Act
    var clone = CounterState.Clone() as CounterState;

    //Assert
    CounterState.Should().NotBeSameAs(clone);
    CounterState.Count.Should().Be(clone.Count);
    CounterState.Guid.Should().NotBe(clone.Guid);
  }

}
