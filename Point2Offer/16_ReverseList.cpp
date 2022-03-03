// copyright @Sam Xu  3/1/2022
// Reverse a list
#include <iostream>
using namespace std;

struct ListNode {
    int m_value;
    ListNode* m_next;

    ListNode(int value) : m_value(value), m_next(nullptr) {}
    ListNode(int value, ListNode* next) : m_value(value), m_next(next) {}
};

ListNode* ReverseList(ListNode* head){
    if (head == nullptr) return nullptr;

    ListNode* p = head->m_next;
    ListNode* q = head->m_next;
    if (q != nullptr) q = q->m_next;
    head->m_next = nullptr;

    while (p != nullptr){
        p->m_next = head;
        head = p;
        p = q;
        if (q != nullptr) q = q->m_next;
    }

    return head;
}

ListNode* ReverseList_2(ListNode* head){
    ListNode* p = head;
    ListNode* q = nullptr; // save the reversed head. 
    while(p != nullptr){
        ListNode* next = p->m_next;
        if (next == nullptr) {
            head = p;
        }

        p->m_next = q;
        q = p;
        p = next;
    }

    return head;
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
        int data[] = {1,4,5,6,7,8,9,10,11,12};
        int n = sizeof(data) /sizeof(data[0]);
        ListNode* head = BuildListNode(data, n);
        PrintList(head);
        ListNode* reversed = ReverseList(head);
        PrintList(reversed);

        ListNode* reversed2 = ReverseList_2(reversed);
        PrintList(reversed2);
    }

    {
        int data[] = {9};
        int n = sizeof(data) /sizeof(data[0]);
        ListNode* head = BuildListNode(data, n);
        PrintList(head);
        ListNode* reversed = ReverseList(head);
        PrintList(reversed);

        ListNode* reversed2 = ReverseList_2(reversed);
        PrintList(reversed2);
    }
    return 0;
}