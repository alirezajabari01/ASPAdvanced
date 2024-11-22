namespace Shop.EndPoint.API.Filters
{
    public class MyResponse
    {
        public MyResponse(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }

        //public void Test()
        //{
        //    Test2();
        //    return;

        //}

        //public void Test2()
        //{
        //    if (true)
        //    {
        //        return;
        //    }

        //    Debug.WriteLine("not acceptable");
        //}
    }
}
