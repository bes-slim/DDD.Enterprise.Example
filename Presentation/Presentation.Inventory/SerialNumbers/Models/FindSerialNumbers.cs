﻿using Application.Inventory.SerialNumbers;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Inventory.SerialNumbers.Models
{
    [Route("/serials", "GET")]
    public class FindSerialNumbers : IReturn<List<SerialNumber>>
    {
        public String Serial { get; set; }
        public DateTime? Effective { get; set; }

        public Guid? ItemId { get; set; }
    }
}