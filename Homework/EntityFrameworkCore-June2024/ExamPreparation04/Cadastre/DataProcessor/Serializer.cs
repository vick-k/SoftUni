using Cadastre.Data;
using Cadastre.DataProcessor.ExportDtos;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                 .Where(p => p.DateOfAcquisition >= DateTime.ParseExact("01/01/2000", "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None))
                 .ToList()
                 .OrderByDescending(p => p.DateOfAcquisition)
                 .ThenBy(p => p.PropertyIdentifier)
                 .Select(p => new
                 {
                     p.PropertyIdentifier,
                     p.Area,
                     p.Address,
                     DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                     Owners = p.PropertiesCitizens
                     .Select(pc => new
                     {
                         pc.Citizen.LastName,
                         MaritalStatus = pc.Citizen.MaritalStatus.ToString()
                     })
                     .OrderBy(pc => pc.LastName)
                 })
                 .ToList();

            return JsonConvert.SerializeObject(properties, Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                .Where(p => p.Area >= 100)
                .OrderByDescending(p => p.Area)
                .ThenBy(p => p.DateOfAcquisition)
                .Select(p => new ExportPropertyDto()
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)
                })
                .ToList();

            return Serialize(properties, "Properties");
        }

        private static string Serialize<T>(T dataTransferObjects, string xmlRootAttributeName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttributeName));

            StringBuilder sb = new StringBuilder();
            using var writer = new StringWriter(sb);

            XmlSerializerNamespaces xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(writer, dataTransferObjects, xmlNamespaces);

            return sb.ToString();
        }
    }
}
