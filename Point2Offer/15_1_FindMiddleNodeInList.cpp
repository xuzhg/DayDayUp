// copyright @Sam Xu  2/28/2022
// Find the middle node from a List.
// If the list has odd number of nodes, returns the middle one.
// If the list has Even number of nodes, returns any one of the the middle two nodes.
#include <iostream>
using namespace std;

struct ListNode{
    int m_value;
    ListNode* m_next;

    ListNode(int value) : m_value(value), m_next(nullptr) {}
    ListNode(int value, ListNode* next) : m_value(value), m_next(next) {}
};

ListNode* FindMiddelNode(ListNode* head, bool firstIfEven){
    if (head == nullptr) return nullptr;

    ListNode* fast = head;
    ListNode* slow = head;

    while(fast->m_next != nullptr && fast->m_next->m_next != nullptr){
        fast = fast->m_next->m_next;
        slow = slow->m_next;
    }

    if (fast->m_next == nullptr) // odd
    {
        return slow;
    }
    else if (firstIfEven){
        return slow;
    }
    else {
        return slow->m_next;
    }
}

void PrintList(ListNode* list){
    cout<<"List: ";
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
    {
        int data[] = {1}; // odd
        int n = sizeof(data) /sizeof(data[0]);
        ListNode* head = BuildListNode(data, n);
        PrintList(head);
        ListNode* mid = FindMiddelNode(head, true);
        cout<<"  ----> Middle Node is : "<< mid->m_value<<endl;
    }

    {
        int data[] = {1, 2}; // Even
        int n = sizeof(data) /sizeof(data[0]);
        ListNode* head = BuildListNode(data, n);
        PrintList(head);
        ListNode* mid = FindMiddelNode(head, true);
        cout<<"  ----> Middle (true) Node is : "<< mid->m_value<<endl;

        mid = FindMiddelNode(head, false);
        cout<<"  ----> Middle (false) Node is : "<< mid->m_value<<endl;
    }

    {
        int data[] = {1, 2, 3, 4, 5, 6, 9, 8, 7}; // odd
        int n = sizeof(data) /sizeof(data[0]);
        ListNode* head = BuildListNode(data, n);
        PrintList(head);
        ListNode* mid = FindMiddelNode(head, true);
        cout<<"  ----> Middle Node is : "<< mid->m_value<<endl;
    }
    
    {
        int data[] = {1, 2, 3, 4, 5, 6, 9, 8, 7, 10}; // even
        int n = sizeof(data) /sizeof(data[0]);
        ListNode* head = BuildListNode(data, n);
        PrintList(head);

        ListNode* mid = FindMiddelNode(head, true);
        cout<<"  ----> Middle (true) Node is : "<< mid->m_value<<endl;

        mid = FindMiddelNode(head, false);
        cout<<"  ----> Middle (false) Node is : "<< mid->m_value<<endl;
    }
    return 0;
}