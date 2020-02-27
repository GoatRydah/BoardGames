﻿using System;

namespace BoardGames.Utility
{
    public class SD
    {
        public const string ManagerRole = "Manager";
        public const string StoreClerk = "Store Clerk";
        public const string CustomerRole = "Customer";
        public const string ShoppingCart = "ShoppingCart";
        public const float SalesTaxPercent = 0.0825f;
        public const float SalesTaxRate = 8.25f;

        //stripe stuff
        public const string PaymentStatusPending = "Payment Pending";
        public const string PaymentStatusApproved = "Payment Approved";
        public const string PaymentStatusRejected = "Payment Rejected";

        public const string StatusSubmitted = "Order Submitted";
        public const string StatusReady = "Order Ready";
        public const string StatusDelivered = "Order Delivered";
        public const string StatusCanceled = "Order Canceled";
        public const string StatusRefunded = "Order Refunded";
    }
}
