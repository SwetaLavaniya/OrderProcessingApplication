using OrderProcessingApplication.Domain;

namespace OrderProcessingApplication.Repository.Interface
{
    public interface IPaymentRequestProcessorRepository
    {
        void Save(PaymentDetails paymentDetails);
    }
}
