using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace awsomAPI
{
    ///-------------------------------------------------------------------------------------------------
    /// <summary>   A program. </summary>
    /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
    ///-------------------------------------------------------------------------------------------------

    public class Program
    {
        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Main entry-point for this application. </summary>
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        /// <param name="args"> An array of command-line argument strings. </param>
        ///-------------------------------------------------------------------------------------------------

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        ///-------------------------------------------------------------------------------------------------
        /// <summary>   Creates web host builder. </summary>
        /// <remarks>   Vanvoljg, 18-Jul-19. </remarks>
        /// <param name="args"> An array of command-line argument strings. </param>
        /// <returns>   The new web host builder. </returns>
        ///-------------------------------------------------------------------------------------------------

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
