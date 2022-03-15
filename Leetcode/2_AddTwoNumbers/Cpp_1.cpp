// copyright @Sam Xu  3/14/2022
// Add two numbers
// Given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.
// You may assume the two numbers do not contain any leading zero, except the number 0 itself.

#include <iostream>
#include <stack> // for print
using namespace std;

struct ListNode {
    int m_value;
    ListNode* m_next;

    ListNode(int value) : m_value(value), m_next(nullptr) {}
    ListNode(int value, ListNode* next) : m_value(value), m_next(next) {}
};

ListNode* AddTwoNumbers(ListNode* node1, ListNode* node2) 
{
    if (node1 == nullptr) return node2;
    if (node2 == nullptr) return node1;

    ListNode* head = nullptr;
    ListNode* last = nullptr;
    ListNode* p = node1;
    ListNode* q = node2;

    int carry = 0;
    while (p != nullptr || q != nullptr)
    {
        int a = 0;
        if (p != nullptr)
        {
            a = p->m_value;
            p = p->m_next;
        }

        int b = 0;
        if (q != nullptr)
        {
            b = q->m_value;
            q = q->m_next;
        }

        int sum = a + b + carry;
        int c = sum % 10;
        carry = sum > c ? 1 : 0;

        ListNode * pNew = new ListNode(c);
        if (head == nullptr){
            head = pNew;
        }
        else{
            last->m_next = pNew;
        }

        last = pNew;
    }

    if (carry != 0){
        ListNode * pNew = new ListNode(carry);
        last->m_next = pNew;
    }

    return head;
}

ListNode* BuildListNode(int *p, int n){
    if (p == NULL){
        throw std::invalid_argument("null list input");
    }

    ListNode* head = NULL;
    for (int i = n -1 ; i >= 0; --i)
    {
        head = new ListNode(p[i], head);
    }

    return head;
}

string GetListAsNumber(ListNode *head)
{
    stack<char> chQ;
    int base = (int)('0');
    ListNode* p = head;
    while(p != nullptr) {
        chQ.push((char)(base + p->m_value));
        p = p->m_next;
    }

    string sum;
    while(!chQ.empty())
    {
        char a = chQ.top();
        chQ.pop();
        sum.push_back(a);
    }

    return sum;
}

int main(){
    
    {
        int data1[] = {2, 4, 3};
        int n = sizeof(data1) /sizeof(data1[0]);
        ListNode* node1 = BuildListNode(data1, n);
        string a = GetListAsNumber(node1);

        int data2[] = {5, 6, 4};
        n = sizeof(data2) /sizeof(data2[0]);
        ListNode* node2 = BuildListNode(data2, n);
        string b = GetListAsNumber(node2);

        ListNode* sum = AddTwoNumbers(node1, node2);
        string c = GetListAsNumber(sum);
        cout << a << " + " << b << " = " << c << endl;
    }

    {
        int data1[] = {9,9,9,9,9,9,9};
        int n = sizeof(data1) /sizeof(data1[0]);
        ListNode* node1 = BuildListNode(data1, n);
        string a = GetListAsNumber(node1);

        int data2[] = {9,9,9,9};
        n = sizeof(data2) /sizeof(data2[0]);
        ListNode* node2 = BuildListNode(data2, n);
        string b = GetListAsNumber(node2);

        ListNode* sum = AddTwoNumbers(node1, node2);
        string c = GetListAsNumber(sum);
        cout << a << " + " << b << " = " << c << endl;
    }

    {
        int data1[] = {0};
        int n = sizeof(data1) /sizeof(data1[0]);
        ListNode* node1 = BuildListNode(data1, n);
        string a = GetListAsNumber(node1);

        int data2[] = {0};
        n = sizeof(data2) /sizeof(data2[0]);
        ListNode* node2 = BuildListNode(data2, n);
        string b = GetListAsNumber(node2);

        ListNode* sum = AddTwoNumbers(node1, node2);
        string c = GetListAsNumber(sum);
        cout << a << " + " << b << " = " << c << endl;
    }
}