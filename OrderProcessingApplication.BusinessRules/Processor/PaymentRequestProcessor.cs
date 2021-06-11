using OrderProcessingApplication.Domain;
using OrderProcessingApplication.Domain.Request;
using OrderProcessingApplication.Domain.Response;
using OrderProcessingApplication.Repository.Interface;
using System;

namespace OrderProcessingApplication.Processor
{
    public class PaymentRequestProcessor
    {
        private readonly IPaymentRequestProcessorRepository _paymentRequestProcessorRepository;

        public PaymentRequestProcessor(IPaymentRequestProcessorRepository PaymentRequestProcessorRepository)
        {
            _paymentRequestProcessorRepository = PaymentRequestProcessorRepository;
        }

        public PaymentResponse ProcessPayment(PaymentRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            _paymentRequestProcessorRepository.Save(new PaymentDetails {
                ProductType = request.ProductType,
                Name = request.Name,
                Code = request.Code,
                Quantity = request.Quantity,
                Amount = request.Amount

            });

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