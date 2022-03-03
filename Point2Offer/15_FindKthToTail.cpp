// copyright @Sam Xu  2/28/2022
// Find the k-th node from the tail of a List.
// The last node in the list is the first node, etc.
#include <iostream>
using namespace std;

struct ListNode{
    int m_value;
    ListNode* m_next;

    ListNode(int value) : m_value(value), m_next(nullptr) {}
    ListNode(int value, ListNode* next) : m_value(value), m_next(next) {}
};

ListNode* FindKthToTailNode(ListNode* head, int k){
    if (head == nullptr || k < 0) return nullptr;

    ListNode* fast = head;
    int n = 1;
    while (fast != nullptr && n < k){
        fast = fast->m_next;
        n++;
    }

    // The list doesn't have more than k node.
    if (fast == nullptr) return nullptr;

    ListNode* slow = head;
    fast = fast->m_next;
    while (fast != nullptr) {
        slow = slow->m_next;
        fast = fast->m_next;
    }

    return slow;
}

void PrintList(ListNode* list){
    while(list != NULL){
        cout << list->m_value;
        list = list->m_next;
        if (list != NULL) {
            cout<<" -> ";
        }
    }

    cout << endl;
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

int main(){

    int data[] = {1, 2, 3, 4, 5, 6, 9, 8, 7, 10};
    int n = sizeof(data) /sizeof(data[0]);
    ListNode* head = BuildListNode(data, n);
    PrintList(head);

    // test
    ListNode* node = FindKthToTailNode(head, 1);
    cout<<"The 1st node from tail:  "<< node->m_value<<endl;

    node = FindKthToTailNode(head, 3);
    cout<<"The 3rd node from tail:  "<< node->m_value<<endl;

    node = FindKthToTailNode(head, 4);
    cout<<"The 4th node from tail:  "<< node->m_value<<endl;

    node = FindKthToTailNode(head, 9);
    cout<<"The 9th node from tail:  "<< node->m_value<<endl;

    node = FindKthToTailNode(head, 10);
    cout<<"The 10th node from tail:  "<< node->m_value<<endl;

    node = FindKthToTailNode(head, 11);
    cout<<"The 11th node from tail:  "<< (node == nullptr ? "Not Found" : "" + node->m_value) <<endl;

    return 0;
}