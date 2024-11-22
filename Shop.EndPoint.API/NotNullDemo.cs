namespace Shop.EndPoint.API
{
    public class NotNullDemo : BaseNotNullDemo
    {
        public void TestMethod<TType>(TType input) where TType : notnull
        {

        }

        public override void View<TType>(TType input) where TType : default
        {

        }


        public override void View<TType>(TType? input) 
        {

        }
    }

    public class BaseNotNullDemo
    {
        public virtual void View<TType>(TType input) 
        {

        }

        public virtual void View<TType>(TType? input) where TType : struct
        {

        }
    }
}
