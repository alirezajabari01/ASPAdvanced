using Shop.EndPoint.API;

namespace Shop.Unit.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var x = new GenericDemo<int>();
            // var x2 = new GenericDemo<string>();
            //var x5 = new Product<string>();
            var x23 = new GenericDemo<Product<string?>>();
        }

        [Fact]
        public void Create_Nullable_Type_Should_Throw_Warning()
        {
            var a = new NotNullDemo();
            a.TestMethod<Input?>(new Input());
            // a.View(new Input());

            Dictionary<int?, int> keyValues = new Dictionary<int?, int>();

            int? key = null;

            keyValues.Add(key, 2);
        }
    }

    public record Input();

    public struct Category
    {
        public Category()
        {

        }
    }


}