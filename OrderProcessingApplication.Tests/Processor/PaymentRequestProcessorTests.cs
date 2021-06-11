using OrderProcessingApplication.Domain.Request;
using OrderProcessingApplication.Domain.Response;
using System;
using Xunit;

namespace OrderProcessingApplication.Processor
{
    public class PaymentRequestProcessorTests
    {
        private PaymentRequestProcessor _processor;

        public PaymentRequestProcessorTests()
        {
            _processor = new PaymentRequestProcessor();
        }
        [Fact]
        public void ShouldReturnPaymentResponse()
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

            // Act
            PaymentResponse response = _processor.ProcessPayment(request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(request.ProductType, response.ProductType);
            Assert.Equal(request.Name, response.Name);
            Assert.Equal(request.Code, response.Code);
            Assert.Equal(request.Quantity, response.Quantity);
            Assert.Equal(request.Amount, response.Amount);

        }

        [Fact]
        public void ShouldThrowNullExceptionWhenRequestIsNull()
        {
           var exception = Assert.Throws<ArgumentNullException>(() => _processor.ProcessPayment(null));
            Assert.Equal("request", exception.ParamName);
        }
    }
}
