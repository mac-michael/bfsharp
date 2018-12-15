namespace Rules.Entities
{
    /// <summary>
    /// Problemy:
    /// - brak automatycznych notyfikacji po zmianie
    /// - brak mo¿liwoœci prostej podmiany regu³y
    /// </summary>
    public class InvoiceLine2
    {
        public decimal ProductPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get { return ProductPrice * Quantity; } }
    }
}