#include <bits/stdc++.h>
using namespace std;

int main()
{
    ifstream f("log.txt");
    ofstream g("error.txt");

    string s;
    while (getline(f, s))
        if (s.find("ERROR") != -1)
            g << s << "\n";

    return 0;
}
