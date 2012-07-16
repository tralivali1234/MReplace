﻿using MReplace;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodTests
{
    [TestClass]
    public class ReplacingMethodsTest
    {
        [TestMethod]
        public void Replace_StaticMethod()
        {
            Assert.AreEqual(2, ClassUnderTest.StaticMethod2());
            using (Replace.Method(() => ClassUnderTest.StaticMethod2()).With(() => ClassUnderTest.StaticMethod1()))
            {
                Assert.AreEqual(1, ClassUnderTest.StaticMethod2());
            }
            Assert.AreEqual(2, ClassUnderTest.StaticMethod2());
        }

        [TestMethod]
        public void Replace_InstanceMethod()
        {
            var tc = new ClassUnderTest();
            Assert.AreEqual(2, tc.Method2());
            using (Replace.Method<ClassUnderTest>(c => c.Method2()).With(c => c.Method1()))
            {
                Assert.AreEqual(1, tc.Method2());
            }
            Assert.AreEqual(2, tc.Method2());
        }

        [TestMethod]
        public void Replace_StaticProperty()
        {
            Assert.AreEqual(2, ClassUnderTest.StaticProperty2);
            using (Replace.Property(() => ClassUnderTest.StaticProperty2).With(() => ClassUnderTest.StaticProperty1))
            {
                Assert.AreEqual(1, ClassUnderTest.StaticProperty2);
            }
            Assert.AreEqual(2, ClassUnderTest.StaticProperty2);
        }

        [TestMethod]
        public void Replace_InstanceProperty()
        {
            var tc = new ClassUnderTest();
            Assert.AreEqual(2, tc.Property2);
            using (Replace.Property<ClassUnderTest>(c => c.Property2).With(c => c.Property1))
            {
                Assert.AreEqual(1, tc.Property2);
            }
            Assert.AreEqual(2, tc.Property2);
        }

        [TestMethod]
        public void Replace_DateTimeNow()
        {
            using (Replace.Property(() => System.DateTime.Now).With(() => FirstJanuaray2000))
            {
                Assert.AreEqual(2000, System.DateTime.Now.Year);
            }
        }

        public static System.DateTime FirstJanuaray2000
        {
            get { return new System.DateTime(2000, 1, 1); }
        }
    }
}