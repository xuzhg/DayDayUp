
// Given an integer n, return the number of structurally unique BST's (binary search trees)
// which has exactly n nodes of unique values from 1 to n.

public class Solution
{
    // n，就是有n个节点，其中一个必然是root node，
    // 当中n个节点中取一个为root node，剩下的是 n-1 个node
    // 此时root node左子树可以是： 0，   1， 2， 3， .... n-1
    // 对应的右子树可以是：        n-1  n-2, ....         0
    // 所以所有可能的BST个数是 （左子树的个数）* （右子树的个数）
    // 注意，这里的 “（左子树的个数）* （右子树的个数）” 一共又 n 组 （0~ n-1）
    // 
    // 如果用 t(i) 表示 i个节点的unique BST个数
    // 那么 n个节点的 unique BST个数就是：
    //  t(n) = t(0)   * t(n-1) +  // 左子树为空，右子树有n-1个节点
    //         t(1)   * t(n-2) +  // 左子树有1个节点，右子树有n-2个节点     
    //         t(2)   * t(n-3) +      
    //         t(4)   * t(n-4) +      
    //         ......    
    //         t(n-2)   * t(1) +      
    //         t(n-1)   * t(0) +  // 左子树有n-1个节点，右子树为空       

    // 我们知道：
    // 1）空树也是一个二叉树，t(0) = 1

    // 2) 1个节点的二叉树，只有一种情况： t(1) = 1

    // 3) 2个节点的二叉树, t(2) = t(0) * t(1) +     一个根节点，空左子树，一个节点右子树
    //                           t(1) * t(0)       一个根节点，一个节点左子树，一个空右子树

    // 4) 3个节点的二叉树, t(3) = t(0) * t(2) +     一个根节点，空左子树，二个节点右子树
    //                           t(1) * t(1)       一个根节点，一个节点左子树，一个节点右子树
    //                           t(2) * t(0)       一个根节点，二个节点左子树，一个空右子树
    //                           
    public static int NumTrees(int n)
    {
        if (n < 0) return 0;
        if (n == 0 || n == 1) return 1;

        int[] t = new int[n+1];
        t[0] = t[1] = 1;
        for (int i = 2; i <= n; ++i)
        {
            t[i] = 0;
            for (int j = 0; j < i; ++j)
            {
                t[i] += t[j] * t[i - j - 1];
            }
        }

        return t[n];
    }
}