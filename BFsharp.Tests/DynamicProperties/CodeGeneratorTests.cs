using System;
using System.Diagnostics;
using System.IO;
using BFsharp.DynamicProperties;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture]
    public class CodeGeneratorTests
    {
        [Test]
        public void PEVerify()
        {
            var dpc = DynamicObjectEmitter.Emitter.CreateDynamicObjectCreator
                (
                    new[]
                        {
                            new DynamicPropertyMetadata("Number", typeof (int)),
                            new DynamicPropertyMetadata("String", typeof (string)),
                            new DynamicPropertyMetadata("DateTime", typeof (DateTime)),
                            new DynamicPropertyMetadata("UInt", typeof (uint)),
                            new DynamicPropertyMetadata("Bool", typeof (bool)),
                            new DynamicPropertyMetadata("Decimal", typeof (decimal))
                        }
                );

            DynamicObjectEmitter.Emitter.SaveAssembly();

            var path = "DynamicObjectEmitter.dll";
            var peverify = @"..\..\..\SolutionItems\PEVerify\PEVerify.exe";

            peverify = Path.Combine(Environment.CurrentDirectory, peverify);

            var process = new Process();
            process.StartInfo.FileName = peverify;
            process.StartInfo.Arguments = path;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.WaitForExit();

            var message = process.StandardOutput.ReadToEnd();
            Debug.WriteLine(message);

            bool verified = message.Contains(
                "All Classes and Methods in DynamicObjectEmitter.dll Verified.");

            Assert.IsTrue(verified);
        }
    }
}