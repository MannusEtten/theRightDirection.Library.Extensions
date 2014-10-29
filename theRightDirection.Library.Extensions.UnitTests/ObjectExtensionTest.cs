using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using theRightDirection.Library.Portable.Extensions;

namespace theRightDirection.Library.UnitTests
{
    [TestClass]
        public class ObjectPropertyMapperExtensionTest
        {
            [TestMethod]
            public void CopyPropertiesSetAllProperties()
            {
                var from = new BaseClass() { Name = "Stefania", Number = 28, Date = DateTime.Today.Date };
                var to = InheritClass.CreateNew(from);
                to.City = "Budapest";
                to.Number.ShouldBeEquivalentTo(28);
                to.Name.ShouldBeEquivalentTo("Stefania");
            }
        }

        class BaseClass
        {
            public string Name { get; set; }
            public int Number { get; set; }
            public DateTime Date { get; set; }
        }

        class InheritClass : BaseClass
        {
            public string City { get; set; }

            public static InheritClass CreateNew(BaseClass baseClass)
            {
                var result = new InheritClass();
                baseClass.CopyProperties(result);
                return result;
            }
        }
}