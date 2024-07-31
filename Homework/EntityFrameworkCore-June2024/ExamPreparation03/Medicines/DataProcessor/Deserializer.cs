namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid Data!";
        private const string SuccessfullyImportedPharmacy = "Successfully imported pharmacy - {0} with {1} medicines.";
        private const string SuccessfullyImportedPatient = "Successfully imported patient - {0} with {1} medicines.";

        public static string ImportPatients(MedicinesContext context, string jsonString)
        {
            var patientsDto = JsonConvert.DeserializeObject<ImportPatientDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();
            List<Patient> patients = new List<Patient>();

            foreach (var patientDto in patientsDto)
            {
                if (!IsValid(patientDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Patient patient = new Patient()
                {
                    FullName = patientDto.FullName,
                    AgeGroup = (AgeGroup)patientDto.AgeGroup,
                    Gender = (Gender)patientDto.Gender,
                };

                foreach (int medicineId in patientDto.Medicines)
                {
                    if (patient.PatientsMedicines.Any(m => m.MedicineId == medicineId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    PatientMedicine patientMedicine = new PatientMedicine()
                    {
                        Patient = patient,
                        MedicineId = medicineId
                    };

                    patient.PatientsMedicines.Add(patientMedicine);
                }

                patients.Add(patient);
                sb.AppendLine(string.Format(SuccessfullyImportedPatient, patient.FullName, patient.PatientsMedicines.Count));
            }

            context.Patients.AddRange(patients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPharmacies(MedicinesContext context, string xmlString)
        {
            var pharmaciesDto = Deserialize<ImportPharmacyDto[]>(xmlString, "Pharmacies");

            StringBuilder sb = new StringBuilder();
            List<Pharmacy> pharmacies = new List<Pharmacy>();

            foreach (var pharmacyDto in pharmaciesDto)
            {
                if (!bool.TryParse(pharmacyDto.NonStop, out bool nonStop))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (!IsValid(pharmacyDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Pharmacy pharmacy = new Pharmacy()
                {
                    Name = pharmacyDto.Name,
                    IsNonStop = nonStop,
                    PhoneNumber = pharmacyDto.PhoneNumber
                };

                foreach (var medicineDto in pharmacyDto.Medicines)
                {
                    if (!IsValid(medicineDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (!DateTime.TryParse(medicineDto.ProductionDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime productionDate) ||
                        !DateTime.TryParse(medicineDto.ExpiryDate, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime expiryDate))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (productionDate >= expiryDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Medicine medicine = new Medicine()
                    {
                        Category = (Category)medicineDto.Category,
                        Name = medicineDto.Name,
                        Price = medicineDto.Price,
                        ProductionDate = productionDate,
                        ExpiryDate = expiryDate,
                        Producer = medicineDto.Producer
                    };

                    if (pharmacy.Medicines.Any(m => m.Name == medicine.Name && m.Producer == medicine.Producer))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    pharmacy.Medicines.Add(medicine);
                }

                pharmacies.Add(pharmacy);
                sb.AppendLine(string.Format(SuccessfullyImportedPharmacy, pharmacy.Name, pharmacy.Medicines.Count));
            }

            context.Pharmacies.AddRange(pharmacies);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }
    }
}
