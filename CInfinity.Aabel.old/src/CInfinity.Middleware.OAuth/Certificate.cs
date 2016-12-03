using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace CInfinity.Middleware.OAuth
{
    public static class Certificate
    {
        private const string CertificatePassword = "idsrv3test";

        public static X509Certificate2 Load()
        {
            var assembly = typeof(Certificate).Assembly;
            var resname = assembly
                .GetManifestResourceNames()
                .Where(n => n.Contains(".pfx"))
                .First();
            
            using (var stream = assembly.GetManifestResourceStream(resname))
            {
                return new X509Certificate2(ReadStream(stream), CertificatePassword);
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }
    }
}