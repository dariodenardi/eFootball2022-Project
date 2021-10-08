using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip.Compression;
using System.IO;

namespace EvoTool.ZlibUnzlib
{
    public static partial class Zlib
    {
        public static byte[] ZlibFilePC(byte[] inputData)
        {
            uint fsize = (uint)inputData.Length;

            Deflater deflater = new Deflater(9);
            deflater.SetInput(inputData);
            deflater.Finish();
            using (var ms = new MemoryStream())
            {
                var outputBuffer = new byte[65536 * 32];
                while (deflater.IsNeedingInput == false)
                {
                    var read = deflater.Deflate(outputBuffer);
                    ms.Write(outputBuffer, 0, read);

                    if (deflater.IsFinished == true)
                        break;
                }

                deflater.Reset();

                uint zsize = (uint)ms.Length;
                byte[] header = { 0x04, 0x10, 0x01, 0x57, 0x45, 0x53, 0x59, 0x53 };
                byte[] b1, b2;
                b1 = BitConverter.GetBytes(zsize);
                b2 = BitConverter.GetBytes(fsize);

                byte[] zlib = ms.ToArray();

                return header.Concat(b1).Concat(b2).Concat(zlib).ToArray();
            }
        }

        //Thanks to sxsxsx for Zlib Code
    }
}