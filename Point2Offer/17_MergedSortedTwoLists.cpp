// copyright @Sam Xu  3/1/2022
// Merge two sorted lists
#include <iostream>
using namespace std;

struct ListNode {
    int m_value;
    ListNode* m_next;

    ListNode(int value) : m_value(value), m_next(nullptr) {}
    ListNode(int value, ListNode* next) : m_value(value), m_next(next) {}
};

ListNode* MergeSortedTwoLists(ListNode* head1, ListNode* head2){
    if (head1 == nullptr) return head2;
    if (head2 == nullptr) return head1;

    ListNode* head = nullptr;
    ListNode* last = nullptr;
    while (head1 != nullptr && head2 != nullptr){

        // Get the next smallest node from two lists
        ListNode* node;
        if (head1->m_value < head2->m_value){
            node = head1;
            head1 = head1->m_next;
        }
        else{
            node = head2;
            head2 = head2->m_next;
        }

        // link to the new list
        if (head == nullptr) {
            head = node;
        }
        else{
            last->m_next = node;
        }

        last = node;
    }

    // last->m_next = nullptr; do not need this

    // link the remaining if we have the remaining
    if (head1 != nullptr) {
        last->m_next = head1;
    }
    else if (head2 != nullptr) {
        last->m_next = head2;
    }

    return head;
}

ListNode* MergeTwoSortedLists_2(ListNode* head1, ListNode* head2){
    if (head1 == nullptr) return head2;
    if (head2 == nullptr) return head1;

    ListNode* head = nullptr;
    if (head1->m_value < head2->m_value) {
        head = head1;
        head->m_next = MergeTwoSortedLists_2(head1->m_next, head2);
    }
    else{
        head = head2;
        head->m_next = MergeTwoSortedLists_2(head1, head2->m_next);
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
        int list[] = {1, 3, 5, 7, 8, 9, 11, 15, 16};
        int n = sizeof(list) /sizeof(list[0]);
        ListNode* head1 = BuildListNode(list, n);
        PrintList(head1);

        int list2[] = {2, 4, 6, 10 };
        n = sizeof(list2) /sizeof(list2[0]);
        ListNode* head2 = BuildListNode(list2, n);
        PrintList(head2);

        ListNode* merged = MergeSortedTwoLists(head1, head2);
        PrintList(merged);
    }

    {
        int list[] = {2, 4, 6, 10 };
        int n = sizeof(list) /sizeof(list[0]);
        ListNode* head1 = BuildListNode(list, n);
        PrintList(head1);

        ListNode* head2 = nullptr;
        ListNode* merged = MergeSortedTwoLists(head1, head2);
        PrintList(merged);
    }


    
    {
        int list[] = {1, 3, 5, 7, 8, 9, 11, 15, 16};
        int n = sizeof(list) /sizeof(list[0]);
        ListNode* head1 = BuildListNode(list, n);
        PrintList(head1);

        int list2[] = {2, 4, 6, 10 };
        n = sizeof(list2) /sizeof(list2[0]);
        ListNode* head2 = BuildListNode(list2, n);
        PrintList(head2);

        ListNode* merged = MergeTwoSortedLists_2(head1, head2);
        PrintList(merged);
    }
    return 0;
}