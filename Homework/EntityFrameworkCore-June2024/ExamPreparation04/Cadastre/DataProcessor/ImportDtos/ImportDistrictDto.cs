using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class ImportDistrictDto
    {
        [XmlAttribute("Region")]
        [Required]
        //[Range(0, 3)]
        public string Region { get; set; } = null!;

        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(80)]
        public string Name { get; set; } = null!;

        [XmlElement("PostalCode")]
        [Required]
        [MaxLength(8)]
        [RegularExpression(@"[A-Z]{2}-[0-9]{5}")]
        public string PostalCode { get; set; } = null!;

        [XmlArray("Properties")]
        public ImportDistrictPropertyDto[] Properties { get; set; } = null!;
    }
}
