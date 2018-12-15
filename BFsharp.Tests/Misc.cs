using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading;
using BFsharp.AOP;
using NUnit.Framework;

namespace BFsharp.Tests
{
    [TestFixture, Ignore]
    public class Misc
    {
        public class Value
        {
            public string Key { get; set; }
        }

        [Test]
        public void Collections()
        {
            int count = (int)1e4;
            int max = 5;
            int search = 677;

            Random r = new Random();

            TestTime.Start(count, () =>
                                  {
                                      var d = new List<Value>();

                                      for (int i = 0; i < max; i++)
                                      {
                                          var key = i.ToString();
                                          d.Add(new Value { Key = key });
                                      }
                                      for (int i = 0; i < search; i++)
                                      {
                                          var a = d.Find(v => v.Key == r.Next(max).ToString());
                                      }
                                  });
            Debug.WriteLine("----");
            TestTime.Start(count, () =>
                                  {
                                      var d = new ListDictionary();

                                      for (int i = 0; i < max; i++)
                                      {
                                          var key = i.ToString();
                                          d.Add(key, new Value { Key = key });
                                      }
                                      for (int i = 0; i < search; i++)
                                      {
                                          var a = (Value)d[r.Next(max).ToString()];
                                      }
                                  });
            Debug.WriteLine("----");
            TestTime.Start(count, () =>
                                  {
                                      var d = new Dictionary<string, Value>();

                                      for (int i = 0; i < max; i++)
                                      {
                                          var key = i.ToString();
                                          d.Add(key, new Value { Key = key });
                                      }
                                      for (int i = 0; i < search; i++)
                                      {
                                          var a = d[r.Next(max).ToString()];
                                      }
                                  });
        }
    }
}