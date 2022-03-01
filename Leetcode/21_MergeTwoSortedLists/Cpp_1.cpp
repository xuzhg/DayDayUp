#include <iostream>
using namespace std;

struct ListNode {
    int m_val;
    ListNode* m_next;

    ListNode() : m_val(0), m_next(nullptr) {}
    ListNode(int x) : m_val(x), m_next(nullptr) {}
    ListNode(int x, ListNode* next) : m_val(x), m_next(next) {}
};

/*
Given the head of two sorted linked lists list1 and list2
Merge two lists in one sorted list
*/
ListNode* MergeTwoLists(ListNode* list1, ListNode* list2)
{
    ListNode* head = NULL;
    ListNode* tail = NULL;

    while (list1 != NULL && list2 != NULL){
        ListNode* cur;
        if (list1->m_val < list2->m_val){
            cur = list1;
            list1 = list1->m_next;
        }
        else{
            cur = list2;
            list2 = list2->m_next;
        }

        if (head == NULL){
            head = cur;
        }
        else{
            tail->m_next = cur;
        }

        tail = cur;
    }

    ListNode* remaining = list1 != NULL ? list1 : list2;
    if (remaining != NULL){
        if (head == NULL){
            head = remaining;
        }
        else{
            tail->m_next = remaining;
        }
    }

    return head;
}

void PrintList(ListNode* list){
    while(list != NULL){
        cout << list->m_val;
        list = list->m_next;
        if (list != NULL) {
            cout<<" -> ";
        }
    }

    cout << endl;
}

int main(){
    // list 1
    int list1[] = {1,2,4,7};
    int n = sizeof(list1) /sizeof(list1[0]);

    ListNode* head1 = NULL;
    for (int i = n -1 ; i >= 0; --i)
    {
        head1 = new ListNode(list1[i], head1);
    }
    PrintList(head1);
    
    // list 2
    int list2[] = {1,3,4,8};
    n = sizeof(list2) /sizeof(list2[0]);

    ListNode* head2 = NULL;
    for (int i = n -1 ; i >= 0; --i)
    {
        head2 = new ListNode(list2[i], head2);
    }

    PrintList(head2);

    // MergeTwoLists
    ListNode* merged = MergeTwoLists(head1, head2);
    PrintList(merged);
}