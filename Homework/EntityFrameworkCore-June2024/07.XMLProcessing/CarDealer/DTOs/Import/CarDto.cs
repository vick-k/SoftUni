using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class CarDto
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("traveledDistance")]
        public long TraveledDistance { get; set; }

        [XmlArray("parts")]
        public CarPartDto[] PartIds { get; set; }
    }

    [XmlType("partId")]
    public class CarPartDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}