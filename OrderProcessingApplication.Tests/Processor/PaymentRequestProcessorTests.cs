using Moq;
using OrderProcessingApplication.Domain;
using OrderProcessingApplication.Domain.Request;
using OrderProcessingApplication.Domain.Response;
using OrderProcessingApplication.Repository.Interface;
using System;
using Xunit;

namespace OrderProcessingApplication.Processor
{
    public class PaymentRequestProcessorTests
    {
        private PaymentRequestProcessor _processor;
        private Mock<IPaymentRequestProcessorRepository> _PaymentRequestProcessorRepositoryMock;
        private PaymentRequest _request;

        public PaymentRequestProcessorTests()
        {
           // Arrange
            _request = new PaymentRequest
            {
                ProductType = ProductOption.PhysicalProduct,
                Name = "Physical Product 1",
                Code = "PP1",
                Quantity = 1,
                Amount = 550

            };

            _PaymentRequestProcessorRepositoryMock = new Mock<IPaymentRequestProcessorRepository>();
            _processor = new PaymentRequestProcessor(_PaymentRequestProcessorRepositoryMock.Object);
        }
        [Fact]
        public void ShouldReturnPaymentResponse()
        {
            // Act
            PaymentResponse response = _processor.ProcessPayment(_request);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(_request.ProductType, response.ProductType);
            Assert.Equal(_request.Name, response.Name);
            Assert.Equal(_request.Code, response.Code);
            Assert.Equal(_request.Quantity, response.Quantity);
            Assert.Equal(_request.Amount, response.Amount);

        }

        [Fact]
        public void ShouldThrowNullExceptionWhenRequestIsNull()
        {
           var exception = Assert.Throws<ArgumentNullException>(() => _processor.ProcessPayment(null));
            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveProcessedPaymentDetails()
        {
            PaymentDetails details = null;
            _PaymentRequestProcessorRepositoryMock.Setup(x => x.Save(It.IsAny<PaymentDetails>()))
                .Callback<PaymentDetails>( pd => details = pd);
            _processor.ProcessPayment(_request);
            _PaymentRequestProcessorRepositoryMock.Verify(x => x.Save(It.IsAny<PaymentDetails>()), Times.Once);
            Assert.NotNull(details);
            Assert.Equal(_request.ProductType, details.ProductType);
            Assert.Equal(_request.Name, details.Name);
            Assert.Equal(_request.Code, details.Code);
            Assert.Equal(_request.Quantity, details.Quantity);
            Assert.Equal(_request.Amount, details.Amount);
        }

        [Theory]
        [InlineData(PaymentResponseCode.PackingSlipGenerated, ProductOption.PhysicalProduct)]
        [InlineData(PaymentResponseCode.DuplicatePackingSlipGenerated, ProductOption.Book)]
        public void ShouldReturnExpectedResponseCode(PaymentResponseCode code, ProductOption option)
        {
            _request.ProductType = option;
           var response =  _processor.ProcessPayment(_request);
            Assert.Equal(code, response.ResponseCode);
        }


    }
}
