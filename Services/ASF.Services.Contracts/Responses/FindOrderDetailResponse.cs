﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ASF.Entities;

namespace ASF.Services.Contracts.Responses
{
    [DataContract]
    public class FindOrderDetailResponse
    {
        [DataMember]
        public OrderDetail Result { get; set; }
    }
}
