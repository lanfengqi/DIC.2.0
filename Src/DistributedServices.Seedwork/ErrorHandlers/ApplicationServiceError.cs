using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

namespace DistributedServices.Seedwork.ErrorHandlers
{
    [DataContract(Name = "ServiceError", Namespace = "DistributedServices.Seedwork")]
    public class ApplicationServiceError
    {
        /// <summary>
        /// Error message that flow to client services
        /// </summary>
        [DataMember(Name = "ErrorMessage")]
        public string ErrorMessage { get; set; }
    }
}
