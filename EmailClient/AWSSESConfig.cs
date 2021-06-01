using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SESClient.EmailClient
{
    public class AWSSESConfig
    {
        public const string NAME = "AWSSES";

        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string Region { get; set; }
    }
}
