using BFsharp.AOP;

//[assembly: NotifyPropertyChanged(AttributeTargetTypes = "BFsharp.Samples.SL.Entites.*")]

namespace BFsharp.Samples.SL.Entites
{
    [NotifyPropertyChanged]
    [Sample(@"Rules\ValidationRule\Attributes", Code.AttributeEntity)]
    public class AttributeEntity : EntityBase
    {
        [Range(4,8)]
        public int Value { get; set; }

        [Range("0.5", "4.3")]
        public decimal Value2 { get; set; }

        [Required]
        public string Total { get; set; }

        [Email]
        public string Email { get; set; }

        [Pattern("a.*", Message="Value must start with letter a.")]
        public string Pattern { get; set; }
    }
}