using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BGITXA_HFT_2021221.Models
{
    public class Television
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        public int? Price { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Brand Brand { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual Order Order { get; set; }

        public int BrandId { get; set; }
        public int OrderId { get; set; }

    }
}
