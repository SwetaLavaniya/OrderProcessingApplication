using OrderProcessingApplication.BusinessRules.RuleEngine;
using Xunit;

namespace OrderProcessingApplication.Tests.RuleEngine
{
    public class PaymentRuleEngineTests
    {
        [Fact]
        public void ShouldGeneratePackingSlipForShippingForPhysicalProduct()
        {
            PaymentRuleEngine paymentRuleEngine = new PaymentRuleEngine();
            var result = paymentRuleEngine.GenerateSlipForShippingForPhysicalProduct();
            
        }
    }
}
