namespace OrderProcessingApplication.Domain
{
    public enum PaymentResponseCode
    {
        PackingSlipGenerated,
        DuplicatePackingSlipGenerated,
        MembershipActivated,
        MembershipUpgraded,
        FreeFirstAidVideoAdded,
        GeneratedCommisionPaymentToAgent,
        InvalidRequest
    }
}