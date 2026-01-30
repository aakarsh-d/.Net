#include <bits/stdc++.h>
using namespace std;

bool isVowel(char c)
{
    c = tolower(c);
    return c=='a'||c=='e'||c=='i'||c=='o'||c=='u';
}

int main()
{
    string s1, s2;
    cin >> s1 >> s2;

    set<char> cons;

    for (char c : s2)
        if (!isVowel(c))
            cons.insert(tolower(c));

    string temp = "";

    for (char c : s1)
        if (isVowel(c) || cons.find(tolower(c)) == cons.end())
            temp += c;

    string result = "";

    for (int i = 0; i < temp.size(); i++)
        if (i == 0 || temp[i] != temp[i - 1])
            result += temp[i];

    cout << result;
    return 0;
}
