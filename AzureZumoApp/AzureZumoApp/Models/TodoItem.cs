using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureZumoApp.Models
{
    class TodoItem
    {
        public string Id { get; set; }
        public string Text { get; set; }

        [UpdatedAt]
        public DateTimeOffset? UpdatedAt { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
