using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BinaryTreeVisualizer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeTree();
        }

        private void InitializeTree()
        {
            // 1 through 7, ordered such that it will produce a perfectly balanced tree
            // We'll start this way until I implement a self-balancing tree
            List<int> initData = new List<int> { 4, 2, 6, 1, 3, 5, 7 };

            BinarySearchTree = new BinarySearchTree<int>(initData);

            InitShowTree();
        }

        private void InitShowTree()
        {
            DoShowTree(BinarySearchTree.Root, 1, 0);
        }

        private void DoShowTree(Node<int> node, int currentHeight, double leftMargin)
        {
            if (node == null)
            {
                return;
            }

            Thickness margin = new Thickness
            {
                //Top = currentHeight * 5,
                Left = leftMargin
            };
            Label label = new Label { Content = node.Data, Margin = margin, Width = 20 };

            if (mainStack.Children.Count < currentHeight)
            {
                var newStackPanel = new StackPanel { Background = brushes[currentHeight % brushes.Count] };
                mainStack.Children.Add(newStackPanel);
            }

            var thisStackPanel = (StackPanel)mainStack.Children[currentHeight - 1];
            thisStackPanel.Children.Add(label);

            // Show children
            DoShowTree(node.Left, currentHeight + 1, Math.Abs(margin.Left + 25) * -2);
            DoShowTree(node.Right, currentHeight + 1, Math.Abs(margin.Left + 25) * 2);
        }

        private BinarySearchTree<int> BinarySearchTree;

        private List<Brush> brushes = new List<Brush> { Brushes.Yellow, Brushes.Red, Brushes.Green };
    }
}
