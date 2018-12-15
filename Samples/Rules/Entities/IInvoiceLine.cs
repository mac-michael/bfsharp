namespace Rules.Entities
{
    public interface IInvoiceLine
    {
        decimal ProductPrice { get; set; }
        decimal Quantity { get; set; }
        decimal Total { get; set; }
    }
}