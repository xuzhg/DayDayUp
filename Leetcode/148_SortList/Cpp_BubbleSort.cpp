// Using Bubble sorting, it's not fast.
// O(n^2)val
#include <iostream>
using namespace std;

struct ListNode {
    int m_val;
    ListNode* m_next;

    ListNode() : m_val(0), m_next(nullptr) {}
    ListNode(int x) : m_val(x), m_next(nullptr) {}
    ListNode(int x, ListNode* next) : m_val(x), m_next(next) {}
};

// Given the head of a linked list, return the list afer sorting it in ascending order.
// 4->2->1->3->4
// ==> 1->2->3->4->4
ListNode* SortList(ListNode* head){
    if (head == NULL || head->m_next == NULL) return head;

    ListNode* last = NULL; // last sorted
    while(head != last){
        // just switch the value, don't change the pointer  
        ListNode* p = head;
        ListNode* q = head -> m_next;
        
        bool changed = false;
        while (q != last){
            if (p->m_val > q->m_val){
                // switch the value
                int temp = p->m_val;
                p->m_val = q->m_val;
                q->m_val = temp;

                changed = true;
            }

            p = q;
            q = q->m_next;
        }

        last = p;

        if (!changed) break;
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

    int list1[] = {4,2,3,1};
    int n = sizeof(list1) /sizeof(list1[0]);

    ListNode* head = BuildListNode(list1, n);
    PrintList(head);

    // SortList
    head = SortList(head);
    PrintList(head);

    // test 2
    int list2[] = {-1,5,3,4, 0};
    n = sizeof(list2) /sizeof(list2[0]);

    head = BuildListNode(list2, n);
    PrintList(head);

    // SortList
    head = SortList(head);
    PrintList(head);

    return 0;
}