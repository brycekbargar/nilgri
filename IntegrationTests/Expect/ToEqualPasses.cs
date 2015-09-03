namespace Nilgiri.IntegrationTests
{
  using Xunit;
  using static Nilgiri.ExpectStyle;

  public partial class StaticExpect
  {
    public partial class _To_Equal
    {
      public class Passes
      {
        [Fact]
        public void Int32()
        {
          var testValue = 1;

          var exFunc = Record.Exception(() => Expect(() => testValue).To.Equal(testValue));
          var exValue = Record.Exception(() => Expect(testValue).To.Equal(testValue));

          Assert.Null(exFunc);
          Assert.Null(exValue);
        }

        [Fact]
        public void String()
        {
          var testValue = @"I'm a string!";

          var exFunc = Record.Exception(() => Expect(() => testValue).To.Equal(testValue));
          var exValue = Record.Exception(() => Expect(testValue).To.Equal(testValue));

          Assert.Null(exFunc);
          Assert.Null(exValue);
        }

        [Fact]
        public void Object()
        {
          var testValue = new { I = "Have ", AtLeast = 3, Properties = true};

          var exFunc = Record.Exception(() => Expect(() => testValue).To.Equal(testValue));
          var exValue = Record.Exception(() => Expect(testValue).To.Equal(testValue));

          Assert.Null(exFunc);
          Assert.Null(exValue);
        }
      }
    }
  }
}
