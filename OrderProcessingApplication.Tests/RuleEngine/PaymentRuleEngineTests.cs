using OrderProcessingApplication.BusinessRules.RuleEngine;
using Xunit;

namespace OrderProcessingApplication.Tests.RuleEngine
{
    public class PaymentRuleEngineTests
    {
        [Fact]
        public void ShouldGeneratePackingSlip()
        {
            PaymentRuleEngine paymentRuleEngine = new PaymentRuleEngine();
            var result = paymentRuleEngine.GenerateSlipForShippingForPhysicalProduct();
            Assert.NotNull(result);
            Assert.Equal("SlipGenerated", result);
        }
    }
}
