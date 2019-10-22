using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Filters.Infrastructure
{
    public class ConcurrentDiagnostics : IDiagnostics
    {
        ConcurrentQueue<string> data;
        public IEnumerable<string> Data => data;

        public ConcurrentDiagnostics()
        {
            data = new ConcurrentQueue<string>();
        }

        public void AddData(string value)
        {
            data.Enqueue(value);
        }
    }
}
