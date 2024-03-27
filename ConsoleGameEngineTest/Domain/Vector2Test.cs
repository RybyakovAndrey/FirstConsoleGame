using ConsoleGameEngine.Domain.Struct;
using NUnit.Framework;

namespace ConsoleGameEngineTest.Domain
{
    public class Vector2Test
    {
        [TestCase]
        public void TestCreateVector()
        {
            var vector = new Vector2();

            Assert.IsTrue(vector.X.Equals(0));
            Assert.IsTrue(vector.Y.Equals(0));
        }

        [TestCase]
        public void TestVectorZero()
        {
            var vector = new Vector2();

            Assert.IsTrue(vector.Equals(Vector2.Zero));
        }

        [TestCase]
        public void TestCheckCompareVector()
        {
            var vector = new Vector2(1, 3);
            var vector2 = new Vector2(3, 3);
            Assert.IsFalse(vector >= vector2);
            Assert.IsTrue(vector <= vector2);
        }

        [TestCase]
        public void TestCheckCompareVector2()
        {
            var vector = new Vector2(2, 3);
            var vector2 = new Vector2(1, 2);
            Assert.IsTrue(vector > vector2);
            Assert.IsFalse(vector < vector2);
        }

        [TestCase]
        public void TestCheckCompareVector3()
        {
            var vector = new Vector2(1, 1);
            var vector2 = new Vector2(2, 1);
            Assert.IsTrue(vector == vector);
            Assert.IsFalse(vector == vector2);
        }

        [TestCase]
        public void TestCheckSumVector()
        {
            var vector = new Vector2(1, 1);
            var vector2 = new Vector2(2, 1);
            Assert.IsTrue(new Vector2(3, 2) == vector2 + vector);
        }

        [TestCase]
        public void TestCheckDifferenceVector()
        {
            var vector = new Vector2(1, 1);
            var vector2 = new Vector2(2, 1);
            Assert.IsTrue(new Vector2(1, 0) == vector2 - vector);
        }

        [TestCase]
        public void TestCheckMultipleVector()
        {
            var vector = new Vector2(1, 1);
            Assert.IsTrue(new Vector2(2.5f, 2.5f) == vector * 2.5f);
        }


        [TestCase]
        public void TestCheckDivisionVector()
        {
            var vector = new Vector2(1, 1);
            Assert.IsTrue(new Vector2(0.5f, 0.5f) == vector / 2);
        }

        [TestCase]
        public void TestCheckDivisionByZeroVector()
        {
            var vector = new Vector2(1, 1);
            Assert.IsTrue(Vector2.Zero == vector / 0);
        }

        [TestCase]
        public void TestCheckToStringVector()
        {
            var vector = new Vector2(1, 1);
            Assert.IsTrue(vector.ToString().Equals("(1 : 1)"));
            vector.X = 2;
            Assert.IsTrue(vector.ToString().Equals("(2 : 1)"));
            Assert.IsTrue(Vector2.Zero.ToString().Equals("(0 : 0)"));
        }

        [TestCase]
        public void TestCheckGetHashCodeVector()
        {
            var vector = new Vector2(3, 1);
            var vector2 = new Vector2(1, 3);

            Assert.IsFalse(vector.GetHashCode() == vector2.GetHashCode());
            var vector3 = new Vector2(1, 3);
            Assert.IsTrue(vector2.GetHashCode() == vector3.GetHashCode());

            var vector4 = new Vector2(0, 1);
            var vector5 = new Vector2(1, 0);
            Assert.IsFalse(vector4.GetHashCode() == vector5.GetHashCode()); 
        }

    }
}
