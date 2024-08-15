namespace Challenge;

public class Solution
{
    /*
        Min Window Substring
        Have the function MinWindowSubstring(strArr) take the array of strings stored in strArr, 
        which will contain only two strings, 
        the first parameter being the string N and the second parameter being a string K of some characters, 
        and your goal is to determine the smallest substring of N that contains all the characters in K. 
        For example: if strArr is ["aaabaaddae", "aed"] then the smallest substring of N that contains 
        the characters a, e, and d is "dae" located at the end of the string. 
        So for this example your program should return the string dae.

        Another example: if strArr is ["aabdccdbcacd", "aad"] then the smallest substring of N that 
        contains all of the characters in K is "aabd" which is located at the beginning of the string. 
        Both parameters will be strings ranging in length from 1 to 50 characters and 
        all of K's characters will exist somewhere in the string N. 
        Both strings will only contains lowercase alphabetic characters.
     */

    // POSSIBLE USAGE:
    // text - searching, summarize/short,
    // NLP - named entity recognition, topic modeling
    // data mining - kind of problems to find segments with keywords
    // logs - find behavioral patterns
    // DNA - find segment with markers
    // inventory management - find a set of resources that meet all requirements
    
    // 2 pointer substring
    // time O(N), foreach on query and scan source - k, moving cursor 2n-k times, k+2n-k = 2n => O(N)
    // space O(1), a map is int[128], fixed space (dictionary was hard, found "bitmap" much easy to implement, and space more efficient)
    public string MinWindowSubstring(string[] strArr)
    {
        // constraints:
        // 1 <= str <= 50
        // lowercase
        // intersections exist

        // 1) hashmap query
        // 2) scan source, 2 pointers, from start/end, use hashmap as a roadmap
        // 3) substring window from source
        
        string source = strArr[0];
        char[] query = strArr[1].ToCharArray();
        int[] map = new int[128]; // ASCII has 128 symbols, char to int
        
        foreach (char c in query)
            map[c]++;

        // right, scan 0 -> ^0, decrease map (find all intersections), return last intersection index
        // left, scan 0 -> ^0, increase map, stop when all map's values are 0 and the next one is intersection

        // how many intersections we should find
        // decreasing is better, then we compare with 0 rather query.Length, should be good for performance, but not sure if it's utilizable
        int finder = query.Length;
        // default window, whole source, worst case
        int left = 0;
        int right = source.Length;
        
        // scan source, from left to right, 2 pointers
        int l = 0;
        int r = 0;
        // right scan, moving right border
        while (r < source.Length)
        {
            // found right intersection
            if (map[source[r]] > 0)
                finder--; // memo finding

            map[source[r]]--; // not intersections would be negative
            r++; // right scan

            // found all required intersections
            // left scan, moving left border, memo min window
            while (finder == 0)
            {
                // found min window
                if (r - l < right - left) {
                    // memo window
                    left = l;
                    right = r;

                    // short exit, found min possible window (first if they are many)
                    // should be good memory hit, as query.Length in cached all the time 
                    // quite specific case, might be not relevant 
                    // if (r - l == query.Length)
                    //     return source.Substring(left, right - left);
                }
                
                map[source[l]]++; // restore origin map values
                
                // found left intersection, which will left the scan frame
                if (map[source[l]] > 0)
                    finder++; // increase finder (increase intersections to find), leads to leaving "left scan" while

                l++; // left scan
            }
        }

        // code goes here  
        return source.Substring(left, right - left);
    }
}