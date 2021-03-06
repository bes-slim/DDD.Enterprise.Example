﻿using Demo.Library.Queries;
using Demo.Library.Responses;
using ServiceStack;
using System;
using System.Collections.Generic;

namespace Demo.Application.ServiceStack.Inventory.Models.Items
{
    [Api("Inventory")]
    [Route("/items", "GET")]
    public class Find : PagedQuery, IReturn<FindResponse>
    {
        public String Number { get; set; }

        public String Description { get; set; }
    }

    public class FindResponse : Base, IIsList<GetResponse>
    {
        public IEnumerable<GetResponse> Results { get; set; }
    }
}