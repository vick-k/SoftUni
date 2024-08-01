﻿using Cadastre.Data.Enumerations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.DataProcessor.ImportDtos
{
    public class ImportCitizenDto
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; } = null!;

        [Required]
        public string BirthDate { get; set; } = null!;

        [Required]
        [EnumDataType(typeof(MaritalStatus))]
        public string MaritalStatus { get; set; } = null!;

        [Required]
        public int[] Properties { get; set; } = null!;
    }
}
