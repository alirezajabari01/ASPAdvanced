using Shop.Application.Contract.IServices.Products;
using System.Reflection;

namespace Shop.Application.UnitOfWorks
{
    [AttributeUsage(AttributeTargets.Method)]
    public class UnitOfWorkAttribute : Attribute
    {
    }


    public class UnitOfWorkAttributeManager
    {
        private readonly HashSet<string> unitOfWorkMethods;
        public UnitOfWorkAttributeManager()
        {
            unitOfWorkMethods = new HashSet<string>();
            SetValue();
        }

        private void SetValue()
        {
            var targets = Assembly.GetExecutingAssembly()
                  .GetTypes()
                  .Where(x => x.IsAssignableTo(typeof(IProductAdminService)) && !x.IsInterface).
                  SelectMany(m =>
                  m.GetMethods()
                  .Where(c => c.GetCustomAttributes()
                  .Any(a => a is UnitOfWorkAttribute)));

            foreach (var target in targets)
            {
                var targetName = "I" + target.DeclaringType.Name + "/" + target.Name;
                unitOfWorkMethods.Add(targetName);
            }
        }

        public bool HasValue(string targetName) => unitOfWorkMethods.TryGetValue(targetName, out _);

    }
}
