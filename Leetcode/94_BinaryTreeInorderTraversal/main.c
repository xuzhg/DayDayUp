// copyright @Zhigang Xu  3/21/2022
// Given the root of a binary tree, return the inorder traversal of its nodes' values.
#include <stdio.h>
#include <stdlib.h>

struct TreeNode{
    int val;
    struct TreeNode* left;
    struct TreeNode* right;
};

void getCountRecursive(struct TreeNode* node, int* count)
{
    if (node == NULL) return;

     *count = *count + 1;

     getCountRecursive(node->left, count);
     getCountRecursive(node->right, count);
}

/*
Get the tree node count
*/
int getCount(struct TreeNode* tree)
{
    int count = 0;
    getCountRecursive(tree, &count);
    return count;
}

void fillIn(struct TreeNode* node, int** out, int* index){
    if (node == NULL) return;

    fillIn(node->left, out, index);

    int i = *index;
    (*out)[i] = node->val;
    *index = *index + 1;
    
    fillIn(node->right, out, index);
}

/*
* Note: The returned array must be molloced, assume caller calls free()
*/
int* inorderTraversal(struct TreeNode* tree, int* returnSize)
{
    if (tree == NULL) return NULL;

    // Get the size
    int count = getCount(tree);
    int* order = (int*)(malloc(sizeof(int) * count));

    *returnSize = 0;
    fillIn(tree, &order, returnSize);

    return order;
}


struct TreeNode* NewNode(int data)
{
    struct TreeNode* node = (struct TreeNode*)malloc(sizeof(struct TreeNode));
    node->val = data;
    node->left = node->right = NULL;
    return node;
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

        struct TreeNode* root = NewNode(1);
        struct TreeNode* node2 = root->right = NewNode(2);
        node2->left = NewNode(3);

        int size = 0;
        int* inOrder = inorderTraversal(root, &size);
        for (int i = 0; i < size; ++i)
        {
            printf("%d,", inOrder[i]);
        }

        printf("\n");

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

        struct TreeNode* root = NewNode(2);
        struct TreeNode* node7 = root->left = NewNode(7);
        struct TreeNode* node5 = root->right = NewNode(5);

        struct TreeNode* node6 = node7->right = NewNode(6);
        node6->left = NewNode(1);
        node6->right = NewNode(11);

        struct TreeNode* node9 = node5->right = NewNode(9);
        node9->left = NewNode(4);

        int size = 0;
        int* inOrder = inorderTraversal(root, &size);
        for (int i = 0; i < size; ++i)
        {
            printf("%d,", inOrder[i]);
        }

        printf("\n");
        // it outputs "7,1,6,11,2,5,4,9,"
    }
    return 0;
}