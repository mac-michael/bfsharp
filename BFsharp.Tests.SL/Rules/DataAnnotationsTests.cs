using System.ComponentModel.DataAnnotations;
using BFsharp.AOP;
using NUnit.Framework;
using SpecUnit;

namespace BFsharp.Tests.SL.Rules
{
    [TestFixture]
    public class DataAnnotationsTests
    {
        [NotifyPropertyChanged]
        public class Annotations : EntityBase<Annotations>
        {
            [StringLength(5)]
            public string Abc { get; set; }

            [System.ComponentModel.DataAnnotations.Range(0,10)]
            public int Number { get; set; }
        }

        [Test]
        public void String()
        {
            ExtensionsOptions<Annotations>.Instance.WithDataAnnotations();

            var a = new Annotations();
            a.Extensions.InitializeRules();
            a.Abc = "abcdefg";

            a.Extensions.BrokenRules.Count.ShouldEqual(1);

            a.Number = 11;
            a.Extensions.BrokenRules.Count.ShouldEqual(2);
        }
    }
}
