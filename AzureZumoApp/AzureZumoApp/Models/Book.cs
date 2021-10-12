using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureZumoApp.Models
{
    class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }

        [UpdatedAt]
        public DateTimeOffset? UpdatedAt { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
