using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using ASF.Entities;

namespace ASF.Services.Contracts.Responses
{
    [DataContract]
    public class AllOrderDetailResponse
    {
        [DataMember]
        public List<OrderDetail> Result { get; set; }
    }
}
