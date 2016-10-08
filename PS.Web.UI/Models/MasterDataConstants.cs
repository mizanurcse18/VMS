using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PS.Web.UI.Models
{
    public static class MasterDataConstants
    {
        public static class ActionType
        {
            public static String INSERT = "INSERT";
            public static String DELETE = "DELETE";
            public static String UPDATE = "UPDATE";
        }
        public static class INVItemStatus
        {
            public static Int32 FRESH = 1;
            public static Int32 REFUBRISHED = 2;
            public static Int32 WASTAGE = 3;
        }
        public static class INVOperationType
        {
            public static Int32 ItemReceive = 1;
            public static Int32 ItemDelivery = 2;
            public static Int32 SalesOrder = 3;
            public static Int32 ItemAdjustment = 4;
        }

        public class InOut
        {
            public static string IN = "IN";
            public static string OUT = "OUT";
        }

        public class INVReceiveType
        {
            public static int CENTRAL = 1;
            public static int GODWON = 2;
        }

        public class SDClientType
        {
            public static string Supplier = "78527522-c670-4118-9e48-26de07ea3607";
        }
    }
}