﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Polo.Framework.Domain
{
   public interface IAggregateRoot<TAggregateRoot>
   {
      IEnumerable<Expression<Func<TAggregateRoot, object>>> GetIncludeExpression();
   }
}
