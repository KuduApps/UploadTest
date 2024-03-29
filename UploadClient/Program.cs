﻿using System;
using System.IO;
using System.Linq;
using System.Net;

namespace UploadClient
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("post [url] [filename] [--chunked]");
            }
            else
            {
                string requestUriString = args[0];
                string path = Path.GetFullPath(args[1]);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                httpWebRequest.Timeout = Int32.MaxValue;
                httpWebRequest.Method = "POST";
                httpWebRequest.Headers["X-FileName"] = Path.GetFileName(path);
                var fileStream = new FileStream(path, FileMode.Open);

                Console.WriteLine("Preparing file upload for {0}", requestUriString);

                if (args.Any(a => a.Trim().StartsWith("--chunked", StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Posting {0} bytes chunked", fileStream.Length);
                    httpWebRequest.SendChunked = true;
                }
                else
                {
                    Console.WriteLine("Posting {0} bytes", fileStream.Length);
                    httpWebRequest.ContentLength = fileStream.Length;
                }

                Console.WriteLine("Copying input data to stream");
                int bufferSize = 1048576;
                using (Stream requestStream = httpWebRequest.GetRequestStream())
                {
                    fileStream.CopyTo(requestStream, bufferSize);
                }

                Console.WriteLine("Getting response");
                using (WebResponse response = httpWebRequest.GetResponse())
                {
                    using (StreamReader streamReader = new StreamReader(response.GetResponseStream()))
                    {
                        Console.WriteLine(streamReader.ReadToEnd());
                    }
                }
            }
        }
    }
}
