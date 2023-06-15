using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utility
{
    public static class Constants
    {
        public static readonly string TrailCreated_ServiceBus_TopicName = "trailcreated-servicebustopic";
        public static readonly string KeyVaultConfiguration__KeyVaultURL = "KeyVaultConfiguration--KeyVaultURL";
        public static readonly string UseInMemoryDatabase = "UseInMemoryDatabase";
        public static readonly string UseSqlite = "UseSqlite";
        public static readonly string DefaultConnection = "DefaultConnection";

        public static readonly string TrailCreated_IsEmailSenderEnabled = "Email__EnableEmailSender";
        public static readonly string TrailCreated_FromEmail = "Email__FromEmail";
    }
}
