using OrderProcessingApplication.BusinessRules.RuleEngine;
using OrderProcessingApplication.Domain;
using Xunit;

namespace OrderProcessingApplication.Tests.RuleEngine
{
    public class RuleEngineTests
    {
        private readonly PaymentRuleEngine _paymentRuleEngine;

        public RuleEngineTests()
        {
            this._paymentRuleEngine = new PaymentRuleEngine();
        }

        [Theory]
        [InlineData(500)]
        public void GeneratePackingSlipIfPaymentDone(int? amount)
        {
           var result = _paymentRuleEngine.GenerateSlipForShippingForPhysicalProduct(amount);
            Assert.Equal("SlipGenerated", result);
            
        }

        [Theory]
        [InlineData(null)]
        public void DontGeneratePackingSlipIfPaymentNotDone(int? amount)
        {
            var result = _paymentRuleEngine.GenerateSlipForShippingForPhysicalProduct(amount);
            Assert.Equal("SlipNotGenerated", result);
            
        }

    }
}
