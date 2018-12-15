using System;
using BFsharp.DynamicProperties;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class SaveLoadTests
    {
        [Test]
        public void SimpleSave()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("name");

            e.Extensions.DynamicProperties["name"] = 4;

            var xml = e.Extensions.DynamicProperties.Save();
            const string xml2 = @"<name>4</name>";

            xml.ShouldEqual(xml2);

        }

        [Test]
        public void NonExistingSave()
        {
            var e = new Entity();
            e.Extensions.AddProperty<int>("name");
            
            var xml = e.Extensions.DynamicProperties.Save();
            const string xml2 = @"";

            xml.ShouldEqual(xml2);
        }

        [Test]
        public void SeveralSave()
        {
            var e = new Entity();
            e.Extensions.AddProperty<string>("name");
            e.Extensions.AddProperty<int>("number");
            //e.Extensions.AddProperty<DateTime>("date");

            e.Extensions.DynamicProperties["name"] = "aa";
            e.Extensions.DynamicProperties["number"] = 5;
            //var dateTime = DateTime.Now;
            //e.Extensions.DynamicProperties["date"] = dateTime;

            var xml = e.Extensions.DynamicProperties.Save();

            // 2010-10-08T11:33:30.221+02:00
            //string d = dateTime.ToString("s");

            const string xml2 = @"<name>aa</name>
<number>5</number>";

            xml.ShouldEqual(xml2);

        }

        [Test]
        public void SaveWithoutSaveOption()
        {
            var e = new Entity();
            e.Extensions.AddProperty<string>("name");
            e.Extensions.AddProperty<int>("number", DynamicPropertyMetadataOptions.None);

            e.Extensions.DynamicProperties["name"] = "aa";
            e.Extensions.DynamicProperties["number"] = 5;

            var xml = e.Extensions.DynamicProperties.Save();

            const string xml2 = @"<name>aa</name>";

            xml.ShouldEqual(xml2);
        }

        public class MyType
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        [Test]
        public void ClassSave()
        {
            var e = new Entity();
            e.Extensions.AddProperty<MyType>("t");

            e.Extensions.DynamicProperties["t"] = new MyType {Name = "abc", Age = 4};
            var xml = e.Extensions.DynamicProperties.Save();

            const string xml2 = @"<t>
  <SaveLoadTests.MyType xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/BFsharp.Tests"">
    <Age>4</Age>
    <Name>abc</Name>
  </SaveLoadTests.MyType>
</t>";

            xml.ShouldEqual(xml2);

        }

        [Test]
        public void DynamicSave()
        {
            var e = new Entity();
            e.Extensions.AllowDynamicProperties();

            e.Extensions.DynamicProperties["name"] = "aa";
            e.Extensions.DynamicProperties["number"] = 5;
            
            var xml = e.Extensions.DynamicProperties.Save();


            const string xml2 = @"<name t=""string"">aa</name>
<number t=""int"">5</number>";

            xml.ShouldEqual(xml2);
        }

        [Test]
        public void SimpleLoad()
        {
            var e = new Entity();
            e.Extensions.AddProperty<string>("abc");
            e.Extensions.DynamicProperties["abc"] = "aa";

            var xml = e.Extensions.DynamicProperties.Save();

            var e2 = new Entity();
            e2.Extensions.AddProperty<string>("abc");
            e2.Extensions.DynamicProperties.Load(xml);

            e2.Extensions.DynamicProperties["abc"].ShouldEqual("aa");
        }

        [Test]
        public void DynamicLoad()
        {
            var e = new Entity();
            e.Extensions.AllowDynamicProperties();
            e.Extensions.DynamicProperties["abc"] = "aa";

            var xml = e.Extensions.DynamicProperties.Save();

            var e2 = new Entity();
            e2.Extensions.AllowDynamicProperties();
            e2.Extensions.DynamicProperties.Load(xml);

            e2.Extensions.DynamicProperties["abc"].ShouldEqual("aa");
        }

        [Test]
        public void DynamicClassLoad()
        {
            var e = new Entity();
            e.Extensions.AllowDynamicProperties();
            e.Extensions.DynamicProperties["t"] = new MyType {Name = "abc", Age = 4};
            
            var xml = e.Extensions.DynamicProperties.Save();

            var e2 = new Entity();
            e2.Extensions.AllowDynamicProperties();
            e2.Extensions.DynamicProperties.Load(xml);

            e2.Extensions.DynamicProperties["t"].ShouldNotBeNull();
            ((MyType) e2.Extensions.DynamicProperties["t"]).Age.ShouldEqual(4);
        }

        [Test]
        public void MiscLoad()
        {
            var e = new Entity();
            e.Extensions.AllowDynamicProperties();
            e.Extensions.AddProperty<string>("abc");
            e.Extensions.DynamicProperties["abc"] = "xxx";
            e.Extensions.DynamicProperties["t"] = new MyType { Name = "abc", Age = 4 };

            var xml = e.Extensions.DynamicProperties.Save();

            var e2 = new Entity();
            e2.Extensions.AllowDynamicProperties();
            e2.Extensions.AddProperty<string>("abc");
            e2.Extensions.DynamicProperties.Load(xml);

            e2.Extensions.DynamicProperties["abc"].ShouldEqual("xxx");
            e2.Extensions.DynamicProperties["t"].ShouldNotBeNull();
            ((MyType)e2.Extensions.DynamicProperties["t"]).Age.ShouldEqual(4);
        }
    }
}