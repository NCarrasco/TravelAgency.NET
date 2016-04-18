using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelAgency.MVC.Util
{
    public class ModelUtil
    {
        public static String GetPaymentManner(String input)
        {
            String result;
            if (input != null)
                input = input.Trim();
            switch (input)
            {
                case "P":
                    result = "Transfer";
                    break;
                case "G":
                    result = "Cache";
                    break;
                default:
                    result = "Unknown";
                    break;
            }
            return result;
        }
    }
}