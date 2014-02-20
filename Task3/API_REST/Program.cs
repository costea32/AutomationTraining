using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace API_REST
{
    class Program
    {
        static void Main(string[] args)
        {
            Talker tk = new Talker();
            tk.Main();
            




            Console.WriteLine("Push ze button");
            Console.ReadLine();
        }

    }
}
