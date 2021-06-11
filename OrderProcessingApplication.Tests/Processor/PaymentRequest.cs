﻿namespace OrderProcessingApplication.Processor
{
    internal class PaymentRequest
    {
        public string ProductType { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
    }
}