using Polo.Framework.Domain;
using Polo.Shop.CustomerContext.Resources;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.CustomerContext.Domain.CustomerAggregate.Exceptions
{
    public class NationalCodeDublicationException : DomainException
    {
        public override string Message =>ExceptionResource.NationalCodeDublicationException;
    }
}
