namespace Shop.EndPoint.API
{
    public class GenericDemo<TEntity> where TEntity : notnull, new()
    {

    }



    public class BaseEntity
    {
        public string ToLower(string text, int? lenght)
        {
            return text;
        }

        public void Call()
        {
            ToLower("", null);
        }
    }

    public interface IBaseEntity
    {

    }

    public class Product : BaseEntity
    {
        public Product(int id)
        {

        }
    }

    public class Product<T> where T : notnull
    {

    }


}
