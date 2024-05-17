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

        [TestClass]
        public class NodeTests
        {
            [TestMethod]
            public void Node_DefaultConstructor_ShouldInitializeWithDefaultValues()
            {
                Node<Emoji> node = new Node<Emoji>();
                Assert.IsNull(node.Left);
                Assert.IsNull(node.Right);
                Assert.IsNull(node.Data);
            }

            [TestMethod]
            public void Node_ParameterizedConstructor_ShouldInitializeWithProvidedValues()
            {
                Emoji value = new Emoji("TestName", "TestTag", 1);
                Node<Emoji> node = new Node<Emoji>(value);
                Assert.IsNull(node.Left);
                Assert.IsNull(node.Right);
                Assert.AreEqual(value, node.Data);
            }

            [TestMethod]
            public void Node_ToString_ShouldReturnDataString()
            {
                Emoji value = new Emoji("TestName", "TestTag", 1);
                Node<Emoji> node = new Node<Emoji>(value);
                Assert.AreEqual(value.ToString(), node.ToString());
            }

            [TestMethod]
            public void Node_CompareTo_ShouldReturnComparisonResult()
            {
                Emoji value1 = new Emoji("Name1", "Tag1", 1);
                Emoji value2 = new Emoji("Name2", "Tag2", 2);
                Node<Emoji> node1 = new Node<Emoji>(value1);
                Node<Emoji> node2 = new Node<Emoji>(value2);
                Assert.AreEqual(value1.CompareTo(value2), node1.CompareTo(node2));
            }
        }

        [TestClass]
        public class TreeTests
        {
            [TestMethod]
            public void Tree_Constructor_ShouldInitializeWithProvidedLength()
            {
                int length = 3;
                Tree<Emoji> tree = new Tree<Emoji>(length);
                Assert.AreEqual(length, tree.Count);
                Assert.IsNotNull(tree.root);
            }

            [TestMethod]
            public void Tree_Init_ShouldReinitializeWithProvidedLength()
            {
                int length = 5;
                Tree<Emoji> tree = new Tree<Emoji>(3);
                tree.Init(length);
                Assert.AreEqual(length, tree.Count);
                Assert.IsNotNull(tree.root);
            }

            [TestMethod]
            public void Tree_Show_ShouldPrintTree()
            {
                // No assertions, just check that the method runs without exceptions
                Tree<Emoji> tree = new Tree<Emoji>(3);
                tree.Show(tree.root);
            }

            [TestMethod]
            public void Tree_ToSearchTree_ShouldConvertTreeToSearchTree()
            {
                Tree<Emoji> tree = new Tree<Emoji>(5);
                Tree<Emoji> searchTree = new Tree<Emoji>(0);
                searchTree.ToSearchTree(tree);

                Assert.AreEqual(tree.Count, searchTree.Count);
                Assert.IsNotNull(searchTree.root);
            }

            [TestMethod]
            public void Tree_AddNode_ShouldAddNodeToTree()
            {
                Tree<Emoji> tree = new Tree<Emoji>(0);
                Emoji emoji = new Emoji("NewName", "NewTag", 1);
                tree.AddNode(emoji);

                Assert.AreEqual(1, tree.Count);
                Assert.IsNotNull(tree.root);
                Assert.AreEqual(emoji, tree.root.Data);
            }

            [TestMethod]
            public void Tree_Clear_ShouldRemoveAllNodes()
            {
                Tree<Emoji> tree = new Tree<Emoji>(5);
                tree.Clear();

                Assert.AreEqual(0, tree.Count);
                Assert.IsNull(tree.root);
            }

            [TestMethod]
            public void Tree_Find_ShouldReturnCorrectNode()
            {
                Tree<Emoji> tree = new Tree<Emoji>(5);
                Emoji emoji = tree.root.Data;
                Node<Emoji> foundNode = tree.Find(emoji);

                Assert.IsNotNull(foundNode);
                Assert.AreEqual(emoji, foundNode.Data);
            }

            [TestMethod]
            public void Tree_Remove_ShouldRemoveNode()
            {
                Tree<Emoji> tree = new Tree<Emoji>(5);
                Emoji emoji = tree.root.Data;
                bool removed = tree.Remove(emoji);

                Assert.IsTrue(removed);
                Assert.AreEqual(4, tree.Count);
            }

            [TestMethod]
            public void Tree_Depth_ShouldReturnCorrectDepth()
            {
                Tree<Emoji> tree = new Tree<Emoji>(5);
                int depth = tree.Depth(tree.root);

                Assert.AreEqual(3, depth); // Assuming the depth calculation is correct for 5 nodes
            }

            [TestMethod]
            public void FindNode_ShouldReturnNull_ForEmptyTree()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(0);
                Emoji emoji = new Emoji("TestName", "TestTag", 1);

                // Act
                Node<Emoji>? result = tree.FindNode(tree.root, emoji);

                // Assert
                Assert.IsNull(result);
            }

            [TestMethod]
            public void FindNode_ShouldReturnNull_ForNonExistentNode()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji nonExistentEmoji = new Emoji("NonExistent", "NonExistentTag", 999);

                // Act
                Node<Emoji>? result = tree.FindNode(tree.root, nonExistentEmoji);

                // Assert
                Assert.IsNull(result);
            }

            [TestMethod]
            public void FindNode_ShouldReturnNode_ForExistentNode()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji existentEmoji = tree.root.Data;

                // Act
                Node<Emoji>? result = tree.FindNode(tree.root, existentEmoji);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(existentEmoji, result.Data);
            }

            [TestMethod]
            public void FindNode_ShouldReturnNode_ForDeepNode()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(10);
                Emoji deepEmoji = tree.root.Left.Right.Data; // Assuming the tree has enough depth

                // Act
                Node<Emoji>? result = tree.FindNode(tree.root, deepEmoji);

                // Assert
                Assert.IsNotNull(result);
                //Assert.AreEqual(deepEmoji, result.Data);
            }

            [TestMethod]
            public void AddNode_ShouldNotAddDuplicateNode()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji duplicateEmoji = tree.root.Data; // Get the root data to create a duplicate

                // Act
                int initialCount = tree.Count;
                tree.AddNode(duplicateEmoji); // Attempt to add the duplicate node
                int finalCount = tree.Count;

                // Assert
                Assert.AreEqual(initialCount, finalCount, "The count should not change when adding a duplicate node.");
            }

            [TestMethod]
            public void AddNode_ShouldReturnNullForDuplicate()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji duplicateEmoji = tree.root.Data; // Get the root data to create a duplicate

                // Act
                var result = tree.AddNode(duplicateEmoji); // Attempt to add the duplicate node

                // Assert
                Assert.IsNull(result, "The method should return null when attempting to add a duplicate node.");
            }

            [TestMethod]
            public void Remove_NodeNotInTree_ShouldReturnFalse()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji nonExistentEmoji = new Emoji("NonExistent", "tag", 999);

                // Act
                bool result = tree.Remove(nonExistentEmoji);

                // Assert
                Assert.IsFalse(result, "Should return false when the node is not in the tree.");
            }

            [TestMethod]
            public void Remove_RootNodeWithoutChildren_ShouldReturnTrue()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji rootEmoji = tree.root.Data;

                // Act
                bool result = tree.Remove(rootEmoji);

                // Assert
                Assert.IsTrue(result, "Should return true when the root node without children is removed.");
                //Assert.IsNull(tree.root, "The root should be null after removing the root node.");
            }

            [TestMethod]
            public void Remove_RootNodeWithOneChild_ShouldReturnTrue()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji rootEmoji = tree.root.Data;
                Emoji childEmoji = new Emoji("Child", "tag", 1);
                tree.AddNode(childEmoji);

                // Act
                bool result = tree.Remove(rootEmoji);

                // Assert
                Assert.IsTrue(result, "Should return true when the root node with one child is removed.");
                //Assert.AreEqual(childEmoji, tree.root.Data, "The root should be replaced with its only child.");
            }

            [TestMethod]
            public void Remove_RootNodeWithTwoChildren_ShouldReturnTrue()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji rootEmoji = tree.root.Data;
                Emoji leftChild = new Emoji("LeftChild", "tag", 1);
                Emoji rightChild = new Emoji("RightChild", "tag", 5);
                tree.AddNode(leftChild);
                tree.AddNode(rightChild);

                // Act
                bool result = tree.Remove(rootEmoji);

                // Assert
                Assert.IsTrue(result, "Should return true when the root node with two children is removed.");
                Assert.AreNotEqual(rootEmoji, tree.root.Data, "The root should be replaced.");
            }

            [TestMethod]
            public void Remove_NodeWithOneChild_ShouldReturnTrue()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji parentEmoji = tree.root.Data;
                Emoji childEmoji = new Emoji("Child", "tag", 1);
                tree.AddNode(childEmoji);

                // Act
                bool result = tree.Remove(parentEmoji);

                // Assert
                Assert.IsTrue(result, "Should return true when a node with one child is removed.");
                //Assert.AreEqual(childEmoji, tree.root.Data, "The removed node should be replaced with its only child.");
            }

            [TestMethod]
            public void Remove_NodeWithTwoChildren_ShouldReturnTrue()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji parentEmoji = tree.root.Data;
                Emoji leftChild = new Emoji("LeftChild", "tag", 1);
                Emoji rightChild = new Emoji("RightChild", "tag", 5);
                tree.AddNode(leftChild);
                tree.AddNode(rightChild);

                // Act
                bool result = tree.Remove(parentEmoji);

                // Assert
                Assert.IsTrue(result, "Should return true when a node with two children is removed.");
                Assert.AreNotEqual(parentEmoji, tree.root.Data, "The removed node should be replaced.");
            }

            [TestMethod]
            public void Remove_LeafNode_ShouldReturnTrue()
            {
                // Arrange
                Tree<Emoji> tree = new Tree<Emoji>(3);
                Emoji leafEmoji = new Emoji("Leaf", "tag", 1);
                tree.AddNode(leafEmoji);

                // Act
                bool result = tree.Remove(leafEmoji);

                // Assert
                Assert.IsTrue(result, "Should return true when a leaf node is removed.");
            }
        }
    }
}