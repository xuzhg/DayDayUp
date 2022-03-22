// copyright @Zhigang Xu  3/21/2022
// Given the root of a binary tree, return the inorder traversal of its nodes' values.
#include <iostream>
#include <vector>
#include <stack>
using namespace std;

struct BinaryTreeNode{
    int m_value;
    BinaryTreeNode* m_left;
    BinaryTreeNode* m_right;

    BinaryTreeNode(int value) : m_value(value), m_left(nullptr), m_right(nullptr){}
    BinaryTreeNode(int value, BinaryTreeNode* left, BinaryTreeNode* right) 
        : m_value(value), m_left(left), m_right(right){}
};

vector<int> preOrderTraversalIteratorly(BinaryTreeNode* root)
{
    vector<int> result;
    if (root == nullptr) return result;
 
    stack<BinaryTreeNode*> visited;
    visited.push(root);

    while(!visited.empty())
    {
        BinaryTreeNode* current = visited.top();
        result.push_back(current->m_value);
        visited.pop(); // remove it from stack, we finish this

        if (current-> m_right != nullptr){
            visited.push(current->m_right);
        }

        if (current-> m_left != nullptr){
            visited.push(current->m_left);
        }
    }

    return result;
}

vector<int> postOrderTraversalIteratorly(BinaryTreeNode* root)
{
    vector<int> result;
    if (root == nullptr) return result;
 
    stack<BinaryTreeNode*> visited;
    if (root->m_right != nullptr) 
        visited.push(root->m_right);
    visited.push(root);
    BinaryTreeNode* current = root->m_left;

    while(!visited.empty())
    {
        while(current != nullptr){

            if (current->m_right != nullptr) 
                visited.push(current->m_right);

            visited.push(current);
            current = current->m_left;
        }
        
        // the top item is left-most node without left child
        current = visited.top();
        visited.pop();

        BinaryTreeNode* nextTop = visited.empty() ? nullptr : visited.top();
        if (current->m_right != nullptr && current->m_right == nextTop)
        {
            BinaryTreeNode* top = current;
            current = visited.top();
            visited.pop();
            visited.push(top);
        } 
        else
        {
            result.push_back(current->m_value);
            current = nullptr;
        }
    }

    return result;
}

int main()
{
    {
        cout<<endl;
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
        
        vector<int> data = preOrderTraversalIteratorly(root);
        cout<<"PreOrder: ";
        for (int i = 0; i < data.size(); ++i)
        {
            cout << data[i] << ",";
        }

        cout<<endl;

        // it outputs   1,3,2

        data = postOrderTraversalIteratorly(root);
        cout<<"PostOrder: ";
        for (int i = 0; i < data.size(); ++i)
        {
            cout << data[i] << ",";
        }

        cout<<endl;
    }

    {
        cout<<endl;
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

        vector<int> data = preOrderTraversalIteratorly(root);
        cout<<"PreOrder: ";
        for (int i = 0; i < data.size(); ++i)
        {
            cout << data[i] << ",";
        }

        cout<<endl;
        // it outputs "7,1,6,11,2,5,4,9,"


        data = postOrderTraversalIteratorly(root);
        cout<<"PostOrder: ";
        for (int i = 0; i < data.size(); ++i)
        {
            cout << data[i] << ",";
        }

        cout<<endl;
    }

    {
        cout<<endl;
        /*    1
            /   \
           2      3
          /  \    /  \
          4   5   6   7
        */

        BinaryTreeNode* root = new BinaryTreeNode(1);
        BinaryTreeNode* node2 = root->m_left = new BinaryTreeNode(2);
        BinaryTreeNode* node3 = root->m_right = new BinaryTreeNode(3);

        node2->m_left = new BinaryTreeNode(4);
        node2->m_right = new BinaryTreeNode(5);

        node3->m_left = new BinaryTreeNode(6);
        node3->m_right = new BinaryTreeNode(7);

        vector<int> data = preOrderTraversalIteratorly(root);
        cout<<"PreOrder: ";
        for (int i = 0; i < data.size(); ++i)
        {
            cout << data[i] << ",";
        }

        cout<<endl;
        // it outputs "7,1,6,11,2,5,4,9,"

        data = postOrderTraversalIteratorly(root);
        cout<<"PostOrder: ";
        for (int i = 0; i < data.size(); ++i)
        {
            cout << data[i] << ",";
        }

        cout<<endl;
    }

    return 0;
}