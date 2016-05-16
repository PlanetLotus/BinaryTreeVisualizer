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
            const int BaseLeftMargin = 255;
            const int BaseRightMargin = 255;
            const int BaseTopMargin = 10;
            const int BaseBottomMargin = 440;

            Thickness margin = new Thickness
            {
                Left = BaseLeftMargin,
                Top = BaseTopMargin,
                Right = BaseRightMargin,
                Bottom = BaseBottomMargin
            };
            DoShowTree(BinarySearchTree.Root, 0, margin);
        }

        private void DoShowTree(Node<int> node, int currentHeight, Thickness margin)
        {
            if (node == null)
            {
                return;
            }

            Label label = new Label { Content = node.Data, Margin = margin, Width = 20 };

            treeGrid.Children.Add(label);

            Thickness newLeftMargin = new Thickness
            {
                Top = margin.Top + 50,
                Left = margin.Left - 25,
                Right = margin.Right + 25,
                Bottom = margin.Bottom - 50
            };

            Thickness newRightMargin = new Thickness
            {
                Top = margin.Top + 50,
                Left = margin.Left + 25,
                Right = margin.Right - 25,
                Bottom = margin.Bottom - 50
            };

            // Show children
            DoShowTree(node.Left, currentHeight + 1, newLeftMargin);
            DoShowTree(node.Right, currentHeight + 1, newRightMargin);
        }

        private BinarySearchTree<int> BinarySearchTree;

        private List<Brush> brushes = new List<Brush> { Brushes.Yellow, Brushes.Red, Brushes.Green };
    }
}
