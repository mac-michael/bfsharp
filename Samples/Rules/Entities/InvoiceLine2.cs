namespace Rules.Entities
{
    /// <summary>
    /// Problemy:
    /// - brak automatycznych notyfikacji po zmianie
    /// - brak mo�liwo�ci prostej podmiany regu�y
    /// </summary>
    public class InvoiceLine2
    {
        public decimal ProductPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get { return ProductPrice * Quantity; } }
    }
}