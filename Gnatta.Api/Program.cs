using System;
using System.Collections.Generic;
using Microsoft.Owin.Hosting;

namespace Gnatta.Api
{
    internal class Program
    {
        private const string BINDING = "http://localhost:3001";
        
        public static void Main(string[] args)
        {
            Console.WriteLine($"App started on ${BINDING}, `exit` to close");
            var app = WebApp.Start<ApiStartup>(BINDING);

            while (Console.ReadLine()?.ToLower() != "exit") {}
            app.Dispose();
        }
    }
}