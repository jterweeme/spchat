using System.IO;
using System.Text;

namespace spserver.Utilities
{
    class BinaryStream
    {
        public BinaryReader Reader { get; }
        public BinaryWriter Writer { get; }

        public BinaryStream(Stream stream)
        {
            Reader = new BinaryReader(stream, Encoding.UTF8);
            Writer = new BinaryWriter(stream, Encoding.UTF8);
        }
    }
}
