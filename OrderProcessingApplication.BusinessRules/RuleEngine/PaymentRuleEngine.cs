namespace OrderProcessingApplication.BusinessRules.RuleEngine
{
    public class PaymentRuleEngine
    {
        public string GenerateSlipForShippingForPhysicalProduct(int? amount)
        {
            if(amount.HasValue)
            {
                return "SlipGenerated";
            }
            
            return "SlipNotGenerated";
            
            
        }
    }
}
