using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.CustomerContext.Domain.CustomerAggregate.Services
{
    public interface INationalCodeDublicationChecker
    {
        bool IsDublicated(string nationalCode);
    }
}
