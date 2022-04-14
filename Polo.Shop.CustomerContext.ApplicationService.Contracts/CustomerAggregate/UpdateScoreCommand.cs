using Polo.Framework.Core.ApplicationService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Polo.Shop.CustomerContext.ApplicationService.Contracts.CustomerAggregate
{
   public class UpdateScoreCommand : Command
   {
      public Guid CustomerId { get; set; }
      public int Score { get; set; }
   }
}
