#include <bits/stdc++.h>
using namespace std;

int digitSum(long long x)
{
    int s = 0;
    while (x > 0)
    {
        s += x % 10;
        x /= 10;
    }
    return s;
}

bool isPrime(int x)
{
    if (x <= 1) return false;
    for (int i = 2; i * i <= x; i++)
        if (x % i == 0)
            return false;
    return true;
}

int main()
{
    int m, n;
    cin >> m >> n;

    int count = 0;

    for (int x = m; x <= n; x++)
    {
        if (!isPrime(x))
        {
            int s1 = digitSum(x);
            int s2 = digitSum(1LL * x * x);
            if (s2 == s1 * s1)
                count++;
        }
    }

    cout << count;
    return 0;
}
