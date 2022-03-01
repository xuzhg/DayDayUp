#include <iostream>
using namespace std;

struct ListNode {
    int m_val;
    ListNode* m_next;

    ListNode() : m_val(0), m_next(nullptr) {}
    ListNode(int x) : m_val(x), m_next(nullptr) {}
    ListNode(int x, ListNode* next) : m_val(x), m_next(next) {}
};

// delete the node in O(1)
void DeleteNode(ListNode** head, ListNode* node) {
    // 1->4->3->2-0->^
    if (head == nullptr || node == nullptr) return;

    // if the deleted node is the head
    if (*head == node){
        *head = node->m_next;
        delete node;
        return;
    }

    // If we are deleting the node in the list
    if (node->m_next != nullptr){
        node->m_val = node->m_next->m_val;
        ListNode* del = node->m_next; // the next node to delete
        node->m_next = node->m_next->m_next;
        delete del;
    }
    else // if we are deleting the last node.
    {
        // we have to find the second last node and delete the last one.
        ListNode* pre = (*head);
        while (pre->m_next != node){
            pre = pre->m_next;
        }
        pre->m_next = nullptr;
        delete node;
    }
}


void PrintList(ListNode* list){
    cout <<" List: { ";
    while(list != nullptr){
        cout << list->m_val;
        list = list->m_next;
        if (list != nullptr) {
            cout<<" -> ";
        }
    }

    cout << " }" << endl;
}

ListNode* BuildListNode(int *p, int n){
    if (p == nullptr){
        throw std::invalid_argument("null list input");
    }

    ListNode* head = nullptr;
    for (int i = n -1 ; i >= 0; --i)
    {
        head = new ListNode(p[i], head);
    }

    return head;
}

ListNode* FindNode(ListNode* head, int value){
    while(head != nullptr){
        if (head->m_val == value){
            return head;
        }

        head = head->m_next;
    }

    return nullptr;
}

int main(){
    int list1[] = {4, 2, 5, 6, 3, 1};
    int n = sizeof(list1) /sizeof(list1[0]);

    ListNode* head = BuildListNode(list1, n);
    PrintList(head);

    // Delete the first one
    ListNode* node = FindNode(head, 4);
    DeleteNode(&head, node);
    PrintList(head);

    // Delete the last one
    node = FindNode(head, 1);
    DeleteNode(&head, node);
    PrintList(head);

    // Delete the middle one
    node = FindNode(head, 6);
    DeleteNode(&head, node);
    PrintList(head);

    // test 2
    int list2[] = {9};
    n = sizeof(list2) /sizeof(list2[0]);

    head = BuildListNode(list2, n);
    PrintList(head);
    node = FindNode(head, 9);
    DeleteNode(&head, node);
    PrintList(head);

    return 0; 
}