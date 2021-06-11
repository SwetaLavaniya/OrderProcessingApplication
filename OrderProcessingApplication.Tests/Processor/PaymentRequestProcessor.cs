    using System;

namespace OrderProcessingApplication.Processor
{
    internal class PaymentRequestProcessor
    {
        public PaymentRequestProcessor()
        {
        }

        internal PaymentResponse ProcessPayment(PaymentRequest request)
        {
            return new PaymentResponse
            {
                ProductType = request.ProductType,
                Name = request.Name,
                Code = request.Code,
                Quantity = request.Quantity,
                Amount = request.Amount
            };
        }
    }
}