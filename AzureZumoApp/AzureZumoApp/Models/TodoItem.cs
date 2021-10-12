using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AzureZumoApp.Models
{
    [Table("TodoItem")]
    class TodoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Text { get; set; }

        [NotMapped]
        [UpdatedAt]
        public DateTimeOffset? UpdatedAt { get; set; }

        [Version]
        public string Version { get; set; }
    }
}
