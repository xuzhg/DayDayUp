// copyright @Sam Xu  3/3/2022
// Mirror a binary tree
#include <iostream>
using namespace std;

struct BinaryTreeNode {
    int m_value;
    BinaryTreeNode* m_left;
    BinaryTreeNode* m_right;
    BinaryTreeNode(int value) : m_value(value), m_left(nullptr), m_right(nullptr) {}
    BinaryTreeNode(int value, BinaryTreeNode* left, BinaryTreeNode* right)
         : m_value(value), m_left(left), m_right(right) {}
};

BinaryTreeNode* MirrorBinaryTree(BinaryTreeNode* root){
    if (root == nullptr) return nullptr;;

    BinaryTreeNode* tmp = root->m_left;
    root->m_left = MirrorBinaryTree(root->m_right);
    root->m_right = MirrorBinaryTree(tmp);
    return root;
}

void PrintPreBinaryTree(BinaryTreeNode* tree){
    if (tree == nullptr) return;
    cout<< tree->m_value <<",";
    PrintPreBinaryTree(tree->m_left);
    PrintPreBinaryTree(tree->m_right);
}

void PrintMidBinaryTree(BinaryTreeNode* tree){
    if (tree == nullptr) return;
    PrintMidBinaryTree(tree->m_left);
    cout<< tree->m_value <<",";
    PrintMidBinaryTree(tree->m_right);
}

int main(){

    {
        /*            8
                   /      \
                  6       10
                /   \    /  \ 
                5    7  9   11
            
        */
        BinaryTreeNode* tree = new BinaryTreeNode(8, 
            new BinaryTreeNode(6,
                new BinaryTreeNode(5), new BinaryTreeNode(7)),
            new BinaryTreeNode(10,
                new BinaryTreeNode(9), new BinaryTreeNode(11)));

        cout<<"Tree Pre:";
        PrintPreBinaryTree(tree);

        cout<<"\nTree Mid:";
        PrintMidBinaryTree(tree);

        tree = MirrorBinaryTree(tree);

        cout<<"\n--------------------------------\n";
        cout<<"Tree Pre:";
        PrintPreBinaryTree(tree);

        cout<<"\nTree Mid:";
        PrintMidBinaryTree(tree);
    }
    cout << "\nSecond test:\n";

    {
        /*            8
                   /      \
                  6        10
                /   \    /  \ 
                5    7  9   11
               /              \
              4                12
        */
        BinaryTreeNode* tree = new BinaryTreeNode(8, 
            new BinaryTreeNode(6,
                new BinaryTreeNode(5, new BinaryTreeNode(4), nullptr), new BinaryTreeNode(7)),
            new BinaryTreeNode(10,
                new BinaryTreeNode(9), new BinaryTreeNode(11, nullptr, new BinaryTreeNode(12))));

        cout<<"Tree Pre:";
        PrintPreBinaryTree(tree);

        cout<<"\nTree Mid:";
        PrintMidBinaryTree(tree);

        /*            8
                   /      \
                 10        6
                /   \    /  \ 
               11    9  7    5
              /               \
            12                 4
        */
        tree = MirrorBinaryTree(tree);

        cout<<"\n--------------------------------\n";
        cout<<"Tree Pre:";
        PrintPreBinaryTree(tree);

        cout<<"\nTree Mid:";
        PrintMidBinaryTree(tree);
    }
    return 0;
}
