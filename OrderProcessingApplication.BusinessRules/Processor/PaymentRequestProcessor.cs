using OrderProcessingApplication.Domain.Request;
using OrderProcessingApplication.Domain.Response;
using System;

namespace OrderProcessingApplication.Processor
{
    public class PaymentRequestProcessor
    {
        public PaymentRequestProcessor(OrderProcessingApplication.Repository.Interface.IPaymentRequestProcessorRepository @object)
        {
        }

        public PaymentResponse ProcessPayment(PaymentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

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