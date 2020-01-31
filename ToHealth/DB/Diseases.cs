using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToHealth.DB
{
    public class Diseases
    {
        [Key]
        public string diseaseName { get; set; }
    }
}
