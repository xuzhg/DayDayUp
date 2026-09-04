public class Solution {
    public string AddBinary(string a, string b) {
        
        int max = a.Length > b.Length ? a.Length : b.Length;
        StringBuilder sb = new StringBuilder(max + 1);

        int carry = 0;
        for (int i = max - 1; i >= 0; i--){
            int ai = a.Length - (max - 1 - i) - 1;
            int bi = b.Length - (max - 1 - i) - 1;

            int av = ai >= 0 ? (int)(a[ai] - '0') : 0;
            int bv = bi >= 0 ? (int)(b[bi] - '0') : 0;

            int sum = av + bv + carry;
            if (sum == 2) {
                sb.Insert(0, '0');
                carry = 1;
            }
            else if (sum == 3) {
                sb.Insert(0, '1');
                carry = 1;
            }
            else if (sum == 1) {
                sb.Insert(0, '1');
                carry = 0;
            }
            else{
                sb.Insert(0, '0');
                carry = 0;
            }
        }

        if (carry == 1) {
            sb.Insert(0, '1');
        }

        return sb.ToString();
    }
}
