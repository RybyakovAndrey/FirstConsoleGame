using FirstConsoleGame.core.Architecture.Domain;
using NUnit.Framework;

namespace FirstConsoleGameTest.TestAcrhitecture
{
    public class BaseGameObjectTest
    {

        [TestCase]
        public void BaseGameObjectTestGetCurrectComponent()
        {
            var gameObject = new GameObject();
            var fakeComponent = new IFakeBaseComponent.Base();

            gameObject.AddComponent(fakeComponent);

            var actual = gameObject.GetComponent<IFakeBaseComponent.Base>();
            Assert.IsTrue(fakeComponent.GetType() == actual.GetType());
        }

        [TestCase]
        public void BaseGameObjectTestGetNullComponent()
        {
            var gameObject = new GameObject();
            
            var actual = gameObject.GetComponent<IFakeBaseComponent.Base>();
            Assert.IsTrue(actual is null);
        }
    }


    internal interface IFakeBaseComponent : IBaseComponent
    {


        internal class Base() : IBaseComponent
        {

        }

    }
}
