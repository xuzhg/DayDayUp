// Using MergeSort
// O(nlogn)val
#include <iostream>
using namespace std;

struct ListNode {
    int m_val;
    ListNode* m_next;

    ListNode() : m_val(0), m_next(nullptr) {}
    ListNode(int x) : m_val(x), m_next(nullptr) {}
    ListNode(int x, ListNode* next) : m_val(x), m_next(next) {}
};

ListNode* SortNode(ListNode* head){
    // If it's empty or only one node, it are done.
    if (head == NULL || head->m_next == NULL) return head;


}

int main(){

}