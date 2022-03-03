// copyright @Sam Xu  3/1/2022
// Determine whether tree B is sub tree of A 
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

bool HasSubTree(BinaryTreeNode* treeA, BinaryTreeNode* treeB){
    if (treeA == nullptr && treeB == nullptr) return true;
    else if (treeA == nullptr) return false;
    else if (treeB == nullptr) return true;    

    if (treeA->m_value != treeB->m_value) return false;
    
    return HasSubTree(treeA->m_left, treeB->m_left) &&
           HasSubTree(treeA->m_right, treeB->m_right);
}

bool DoesTreeAHaveTreeB(BinaryTreeNode* treeA, BinaryTreeNode* treeB){
    if (treeA == nullptr || treeB == nullptr ) return false;

    if (HasSubTree(treeA, treeB))
        return true;

    if (DoesTreeAHaveTreeB(treeA->m_left, treeB))
        return true;

    return DoesTreeAHaveTreeB(treeA->m_right, treeB);
}


void DeleteBinaryTreeNode(BinaryTreeNode* tree){
    if (tree == nullptr) return;
    DeleteBinaryTreeNode(tree->m_left);
    DeleteBinaryTreeNode(tree->m_right);
    delete tree;
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
    /*           8
               /    \
              8      7
            /    \
            9     2
                /    \
               4      7
    */
    BinaryTreeNode* treeA = new BinaryTreeNode(8, 
        new BinaryTreeNode(8,
            new BinaryTreeNode(9), new BinaryTreeNode(2,
                new BinaryTreeNode(4), new BinaryTreeNode(7))),
        new BinaryTreeNode(7));

    cout<<"Tree-A Pre:";
    PrintPreBinaryTree(treeA);

    cout<<"\nTree-A Mid:";
    PrintMidBinaryTree(treeA);
     /*
              8  
             /  \
            9    2
    */
    BinaryTreeNode* treeB = new BinaryTreeNode(8,
         new BinaryTreeNode(9), new BinaryTreeNode(2));
    cout<<"\nTree-B Pre:";
    PrintPreBinaryTree(treeB);
    cout<<"\nTree-B Mid:";
    PrintMidBinaryTree(treeB);
    cout<<endl;

    bool ok = DoesTreeAHaveTreeB(treeA, treeB);
    if (ok) {
        cout << "Tree-A contains Tree-B"<<endl;
    }
    else{
        cout << "Tree-A doesn't contain Tree-B"<<endl;
    }

    DeleteBinaryTreeNode(treeA);
    DeleteBinaryTreeNode(treeB);
    return 0;
}