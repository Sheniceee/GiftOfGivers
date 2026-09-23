using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftOfTheGivers.Helpers
{
    public static class DonationHelper
    {
        public static string FormatCertificate(string number) => $"GOTG-{number.ToUpper()}-2025";

        public static decimal CalctOTAL(decimal amount) => amount * 1.5m;

        public static string ThankYou(string name) => $"Shukran {name} ! Your donation brings hope.";
    }
}
