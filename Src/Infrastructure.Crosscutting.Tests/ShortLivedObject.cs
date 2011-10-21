using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Crosscutting.Tests
{
    public class ShortLivedObject
        : IDisposable
    {
        bool _IsDisposed = false;
        public bool IsDisposed { get { return _IsDisposed; } }
        public void Dispose()
        {
            _IsDisposed = true;
        }
    }
}
