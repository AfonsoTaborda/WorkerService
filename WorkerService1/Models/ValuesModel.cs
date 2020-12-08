using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WorkerService1.Models
{
    public class ValuesModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int MicrocontrollerID { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Dust { get; set; }
        public bool DoorOpen { get; set; }
        public float Power { get; set; }
    }
}
