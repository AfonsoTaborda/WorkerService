﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkerService1.Models
{
    class NotificationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int MicrocontrollerID { get; set; }
        public string NotificationDetails { get; set; }
    }
}
