namespace Nilgiri.Specs.Core
{
  using Xunit;
  using Nilgiri.Core;
  using Nilgiri.Tests.Common;

  using Subject = Nilgiri.Core.BooleanAsserter;
  public partial class BooleanAsserter
  {
    public class Normal
    {
      private Subject _subject;

      public Normal()
      {
        _subject = new Subject();
      }

      [Fact]
      public void Boolean()
      {
        var testStatePass = new AssertionState<bool>(() => true);
        var testStateFail = new AssertionState<bool>(() => false);

        var exPass = Record.Exception(() => _subject.Assert(testStatePass));
        var exFail = Record.Exception(() => _subject.Assert(testStateFail));

        Assert.Null(exPass);
        Assert.NotNull(exFail);
      }

      [Fact]
      public void ValueTypes()
      {
        var testState = new AssertionState<int>(() => 1);

        var exFail = Record.Exception(() => _subject.Assert(testState));

        Assert.NotNull(exFail);
      }

      [Fact]
      public void ReferenceTypes()
      {
        var testState = new AssertionState<StubClass>(() => new StubClass());

        var exFail = Record.Exception(() => _subject.Assert(testState));

        Assert.NotNull(exFail);
      }
    }
  }
}
