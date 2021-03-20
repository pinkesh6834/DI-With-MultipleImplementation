using DI_With_MultipleImplementation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DI_With_MultipleImplementation.Shared
{
    public delegate IService ServiceResolver(string key);
}
