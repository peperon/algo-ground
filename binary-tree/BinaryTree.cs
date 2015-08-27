using System;

namespace DataStructures
{
    public class BinaryTree<T>
        where T : IComparable<T>
    {
        private TreeNode<T> _root;

        public BinaryTree()
        {
            _root = null;
        }

        public TreeNode<T> Search(T value)
        {
            TreeNode<T> current = _root;
            while (current != null && (current.Value.CompareTo(value) != 0))
            {
                current = current.Value.CompareTo(value) > 0 ? current.LeftChild : current.RightChild;
            }

            return current;
        }

        public TreeNode<T> Min(TreeNode<T> subTree = null)
        {
            TreeNode<T> current = subTree ?? _root;
            while (current != null && current.LeftChild != null)
            {
                current = current.LeftChild;
            }

            return current;
        }

        public TreeNode<T> Max(TreeNode<T> subTree = null)
        {
            TreeNode<T> current = subTree ?? _root;
            while (current != null && current.RightChild != null)
            {
                current = current.RightChild;
            }

            return current;
        }

        public void Insert(T value)
        {
            var newNode = new TreeNode<T>(value);
            TreeNode<T> temporaryNode = null;
            TreeNode<T> currentNode = _root;
            while (currentNode != null)
            {
                temporaryNode = currentNode;
                currentNode = currentNode.Value.CompareTo(value) > 0 ? currentNode.LeftChild : currentNode.RightChild;
            }

            newNode.Parent = temporaryNode;

            if (temporaryNode == null)
            {
                _root = newNode;
            }
            else if (newNode.Value.CompareTo(temporaryNode.Value) < 0)
            {
                temporaryNode.LeftChild = newNode;
            }
            else
            {
                temporaryNode.RightChild = newNode;
            }
        }

        public void Delete(T value)
        {
            TreeNode<T> nodeForDeletion = Search(value);
            if (nodeForDeletion == null)
            {
                throw new InvalidOperationException("This node does not exist");
            }

            if (nodeForDeletion.LeftChild == null)
            {
                Transplant(nodeForDeletion, nodeForDeletion.RightChild);
            }
            else if (nodeForDeletion.RightChild == null)
            {
                Transplant(nodeForDeletion, nodeForDeletion.LeftChild);
            }
            else
            {
                TreeNode<T> rightSubTreeMinimum = Min(nodeForDeletion.RightChild);
                if (rightSubTreeMinimum.Parent != nodeForDeletion)
                {
                    Transplant(rightSubTreeMinimum, rightSubTreeMinimum.RightChild);
                    rightSubTreeMinimum.RightChild = nodeForDeletion.RightChild;
                    rightSubTreeMinimum.RightChild.Parent = rightSubTreeMinimum;
                }
                Transplant(nodeForDeletion, rightSubTreeMinimum);
                rightSubTreeMinimum.LeftChild = nodeForDeletion.LeftChild;
                rightSubTreeMinimum.LeftChild.Parent = rightSubTreeMinimum;
            }
        }

        private void Transplant(TreeNode<T> toBeReplaced, TreeNode<T> replace)
        {
            if (toBeReplaced.Parent == null)
            {
                _root = replace;
            }
            else if (toBeReplaced == toBeReplaced.Parent.LeftChild)
            {
                toBeReplaced.Parent.LeftChild = replace;
            }
            else
            {
                toBeReplaced.Parent.RightChild = replace;
            }

            if (replace != null)
            {
                replace.Parent = toBeReplaced.Parent;
            }
        }
    }
}
