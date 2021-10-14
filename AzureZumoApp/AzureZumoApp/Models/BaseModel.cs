using Microsoft.WindowsAzure.MobileServices;
using System;

namespace AzureZumoApp.Models
{
    public abstract class BaseModel
    {
        public string Id { get; set; }

        [UpdatedAt]
        public DateTimeOffset? UpdatedAt { get; set; }

        [CreatedAt]
        public DateTimeOffset? CreatedAt { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
