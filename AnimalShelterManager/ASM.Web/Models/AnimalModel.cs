using System;
using System.ComponentModel.DataAnnotations;

namespace ASM.Web.Models
{
    public class AnimalModel
    {
        public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public DateTime DoB { get; set; }
    }
}
