namespace OrderProcessingApplication.Domain.Response
{
    public class PaymentResponse : PaymentDetailsBase
    {
        public PaymentResponseCode ResponseCode { get; set; }
    }
}