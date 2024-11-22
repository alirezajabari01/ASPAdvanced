using Castle.DynamicProxy;
using Shop.InfraStructure.UnitOfWorks;

namespace Shop.Application.UnitOfWorks
{
    public class UnitOfWorkInterceptor : IInterceptor
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UnitOfWorkAttributeManager unitOfWorkAttributeManager;

        public UnitOfWorkInterceptor(IUnitOfWork unitOfWork, UnitOfWorkAttributeManager unitOfWorkAttributeManager)
        {
            this.unitOfWork = unitOfWork;
            this.unitOfWorkAttributeManager = unitOfWorkAttributeManager;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                var targetName = invocation.Method.DeclaringType.Name + "/" + invocation.Method.Name;
                
                if (unitOfWorkAttributeManager.HasValue(targetName))
                {
                    unitOfWork.Begin();
                    invocation.Proceed();
                    unitOfWork.Commit();
                }
                else
                {
                    invocation.Proceed();
                }
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
            }

        }
    }
}
