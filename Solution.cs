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

        int finder = query.Length;
        int left = 0;
        int right = source.Length;
        int l = 0;
        int r = 0;
        
        while (r < source.Length)
        {
            // found right intersection
            if (map[source[r]] > 0)
                finder--; // memo finding

            map[source[r]]--; // not intersections would be negative
            r++; // right scan

            // found required intersections
            while (finder == 0)
            {
                if (r - l < right - left) {
                    // memo window
                    left = l;
                    right = r; 
                }
                
                map[source[l]]++; // restore origin map values
                
                if (map[source[l]] > 0)
                    finder++; // found left intersection, increase finder.

                l++; // left scan
            }
        }

        // code goes here  
        return source.Substring(left, right - left);
    }
}