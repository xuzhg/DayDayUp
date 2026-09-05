public class Solution {
    public int LengthOfLongestSubstring(string s) {
        
        HashSet<char> set = new HashSet<char>();

        int res = 0;
        int first = 0;

        for (int j = 0; j < s.Length; j++) {
            while (set.Contains(s[j])) {
                set.Remove(s[first]);
                first++;
            }
            set.Add(s[j]);
            res = set.Count > res ? set.Count : res;
        }
        
        return res;
    }
}
