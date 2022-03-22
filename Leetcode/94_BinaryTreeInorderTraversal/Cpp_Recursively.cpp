// copyright @Zhigang Xu  3/21/2022
// Given the root of a binary tree, return the inorder traversal of its nodes' values.
#include <iostream>
#include <vector>
using namespace std;

struct BinaryTreeNode{
    int m_value;
    BinaryTreeNode* m_left;
    BinaryTreeNode* m_right;

    BinaryTreeNode(int value) : m_value(value), m_left(nullptr), m_right(nullptr){}
    BinaryTreeNode(int value, BinaryTreeNode* left, BinaryTreeNode* right) 
        : m_value(value), m_left(left), m_right(right){}
};


void inorderTraversalRecurse(BinaryTreeNode* node, vector<int>& values)
{
    if (node == nullptr) return;

    if (node->m_left != nullptr)
        inorderTraversalRecurse(node->m_left, values);

    values.push_back(node->m_value);

    if (node->m_right != nullptr)
        inorderTraversalRecurse(node->m_right, values);
}


vector<int> inorderTraversalRecurse(BinaryTreeNode* root)
{
    vector<int> result;
    if (root == nullptr) return result;

    inorderTraversalRecurse(root, result);

    return result;
}

int main()
{
    {
        /*    1
               \
                2
                / 
               3
        Let us create Binary Tree as shown
        */

        BinaryTreeNode* root = new BinaryTreeNode(1,
            nullptr,
            new BinaryTreeNode(2,
                new BinaryTreeNode(3),
                nullptr));
        
        vector<int> data = inorderTraversalRecurse(root);
        for (int i = 0; i < data.size(); ++i)
        {
            cout << data[i] << ",";
        }

        cout<<endl;

        // it outputs   1,3,2
    }

    {
        /*    2
            /  \
           7     5
           \      \
            6      9
            / \    /
            1  11 4
        Let us create Binary Tree as shown
        */

        BinaryTreeNode* root = new BinaryTreeNode(2);
        BinaryTreeNode* node7 = root->m_left = new BinaryTreeNode(7);
        BinaryTreeNode* node5 = root->m_right = new BinaryTreeNode(5);

        BinaryTreeNode* node6 = node7->m_right = new BinaryTreeNode(6);
        node6->m_left = new BinaryTreeNode(1);
        node6->m_right = new BinaryTreeNode(11);

        BinaryTreeNode* node9 = node5->m_right = new BinaryTreeNode(9);
        node9->m_left = new BinaryTreeNode(4);

        vector<int> data = inorderTraversalRecurse(root);
        for (int i = 0; i < data.size(); ++i)
        {
            cout << data[i] << ",";
        }

        cout<<endl;
        // it outputs "7,1,6,11,2,5,4,9,"
    }
    return 0;
}