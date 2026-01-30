#include <bits/stdc++.h>
using namespace std;

int main()
{
    string s;
    getline(cin, s);

    string t = "";
    for (int i = 0; i < s.size(); i++)
        if (i == 0 || s[i] != s[i - 1])
            t += s[i];

    stringstream ss(t);
    string word, result = "";

    while (ss >> word)
    {
        for (int i = 0; i < word.size(); i++)
        {
            if (i == 0)
                word[i] = toupper(word[i]);
            else
                word[i] = tolower(word[i]);
        }
        if (!result.empty())
            result += " ";
        result += word;
    }

    cout << result;
    return 0;
}
