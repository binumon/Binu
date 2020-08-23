using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace Insurance.Dal
{
   public class AppConfiguration
    {
       
        public static IConfiguration configuration { get; set; }
        static AppConfiguration()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            configuration = builder.Build();
        }
        public static string Get()
        {
            // return configuration["ConnectionStrings:PrimeAdminConnection"];
            string conString = Microsoft
    .Extensions
    .Configuration
    .ConfigurationExtensions
    .GetConnectionString(configuration, "PrimeAdminConnection");
          return  conString;
        }
    }
}
