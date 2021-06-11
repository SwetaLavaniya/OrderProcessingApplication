using OrderProcessingApplication.Domain.Request;
using OrderProcessingApplication.Domain.Response;

namespace OrderProcessingApplication.Processor
{
    public class PaymentRequestProcessor
    {
        public PaymentRequestProcessor()
        {
        }

        public PaymentResponse ProcessPayment(PaymentRequest request)
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