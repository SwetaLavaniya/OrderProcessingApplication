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

            
            _paymentRequestProcessorRepository.Save(CreatePaymentDetails<PaymentDetails>(request));
            var response = CreatePaymentDetails<PaymentResponse>(request);

            // if else can also be converted to 
            if (request.ProductType == ProductOption.PhysicalProduct)
            {
                response.ResponseCode = PaymentResponseCode.PackingSlipGenerated;
            }
            else if (request.ProductType == ProductOption.Book)
            {
                response.ResponseCode = PaymentResponseCode.DuplicatePackingSlipGenerated;
            }

            return response;
        }

        
        private static T CreatePaymentDetails<T>(PaymentRequest request) where T: PaymentDetailsBase, new ()
        {
            return new T
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