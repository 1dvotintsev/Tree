using Tree;
using CustomLibrary;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestClass]
        public class TestNode
        {
            [TestMethod]
            public void TestMethod1()
            {
                Node<Emoji> node = new Node<Emoji>();

                Assert.AreEqual(node.Left, node.Right);
               
            }

            [TestMethod]
            public void TestMethod2()
            {
                Node<Emoji> node1 = new Node<Emoji>();
                
                Emoji emoji = new Emoji();
                emoji.RandomInit();
                Node<Emoji> node2 = new Node<Emoji>(emoji);

                node1.Data = emoji;
                node1.Left = node2;
                node1.Right = node2;

                Assert.AreEqual(node1.Data, emoji);
                Assert.AreEqual(node2.Data, emoji);
            }

            [TestMethod]
            public void TestMethod3()
            {
                Node<Emoji> node1 = new Node<Emoji>();
                Emoji emoji = new Emoji();
                emoji.RandomInit();
                Node<Emoji> node2 = new Node<Emoji>(emoji);

                Assert.AreEqual(node2.ToString(), emoji.ToString());
                Assert.AreEqual(node1.ToString(), "");
            }

            [TestMethod]
            public void TestMethod4()
            {
                Emoji emoji = new Emoji();
                emoji.RandomInit();
                Node<Emoji> node2 = new Node<Emoji>(emoji);

                Emoji emoji1 = new Emoji();
                emoji1.RandomInit();
                emoji1.Name = "1";
                Node<Emoji> node1 = new Node<Emoji>(emoji1);

                Assert.IsTrue (0 > node1.CompareTo(node2));
            }
        }

        [TestClass]
        public class TestTree
        {
            [TestMethod] 
            public void TestTree1()
            {
                Tree<Emoji> tree = new Tree<Emoji>(5);

                Assert.AreEqual(5, tree.Count);
            }
        }
    }
}