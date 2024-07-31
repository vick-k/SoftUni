using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDto
    {
        [XmlAttribute("non-stop")]
        [Required]
        public string NonStop { get; set; } = null!;

        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [XmlElement("PhoneNumber")]
        [Required]
        [MaxLength(14)]
        [RegularExpression(@"\([0-9]{3}\) [0-9]{3}-[0-9]{4}")]
        public string PhoneNumber { get; set; } = null!;

        [XmlArray("Medicines")]
        public ImportPharmacyMedicineDto[] Medicines { get; set; } = null!;
    }
}
