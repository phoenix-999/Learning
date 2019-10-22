using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Filters.Infrastructure
{
    public interface IDiagnostics
    {
        IEnumerable<string> Data { get; }

        void AddData(string value);
    }
}
