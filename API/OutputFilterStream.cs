using System;
using System.IO;

namespace API
{
    class OutputFilterStream : Stream
    {
        private readonly Stream InnerStream;
        private readonly MemoryStream CopyStream;

        public OutputFilterStream(Stream inner)
        {
            InnerStream = inner;
            CopyStream = new MemoryStream();
        }

        public string ReadStream()
        {
            lock (InnerStream)
            {
                if (CopyStream.Length <= 0L ||
                    !CopyStream.CanRead ||
                    !CopyStream.CanSeek)
                {
                    return String.Empty;
                }

                long pos = CopyStream.Position;
                CopyStream.Position = 0L;
                try
                {
                    return new StreamReader(CopyStream).ReadToEnd();
                }
                finally
                {
                    try
                    {
                        CopyStream.Position = pos;
                    }
                    catch { }
                }
            }
        }


        public override bool CanRead
        {
            get { return InnerStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return InnerStream.CanSeek; }
        }

        public override bool CanWrite
        {
            get { return InnerStream.CanWrite; }
        }

        public override void Flush()
        {
            InnerStream.Flush();
        }

        public override long Length
        {
            get { return InnerStream.Length; }
        }

        public override long Position
        {
            get { return InnerStream.Position; }
            set { CopyStream.Position = InnerStream.Position = value; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return InnerStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            CopyStream.Seek(offset, origin);
            return InnerStream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            CopyStream.SetLength(value);
            InnerStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            CopyStream.Write(buffer, offset, count);
            InnerStream.Write(buffer, offset, count);
        }
    }
}
