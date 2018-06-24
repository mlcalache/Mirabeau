using System.Collections.Generic;

namespace Mirabeau.Domain.Interfaces.Container
{
    public interface IDomainContainer
    {
        IEnumerable<TService> GetAllInstances<TService>();

        TService GetInstance<TService>();
    }
}