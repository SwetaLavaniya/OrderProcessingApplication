using OrderProcessingApplication.Domain.Request;
using OrderProcessingApplication.Domain.Response;
using Xunit;

namespace OrderProcessingApplication.Processor
{
    public class PaymentRequestProcessorTests
    {
        [Fact]
        public void ReturnSuccessPaymentResponseWithPaymentRequestDetails()
        {
            // Arrange
            var request = new PaymentRequest
            {
                ProductType = "Physical Product",
                Name = "Physical Product 1",
                Code = "PP1",
                Quantity = 1,
                Amount = 550

            };

            var processor = new PaymentRequestProcessor();

            // Act
            PaymentResponse response = processor.ProcessPayment(request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(request.ProductType, response.ProductType);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Code, response.Code);
            Assert.Equal(request.Quantity, response.Quantity);
            Assert.Equal(request.Amount, response.Amount);

        }
    }
}
