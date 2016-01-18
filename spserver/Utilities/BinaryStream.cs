using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace spserver.Utilities
{
    class BinaryStream
    {
        public BinaryReader Reader { get; }
        public BinaryWriter Writer { get; }

        public BinaryStream(Stream stream)
        {
            Reader = new BinaryReader(stream);
            Writer = new BinaryWriter(stream);
        }
    }
}
