using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


class Program{
    static void Main(string[] args){
    // string val="abc123";
    // string pattern=@"\d"; //true
    // string val="123_123";
    // string pattern=@"\d"; 
    // bool reg=Regex.IsMatch(val,pattern);
    // Console.WriteLine(reg);

    // Match m = Regex.Match("Amount: 50000",@"\d+");
    // Console.WriteLine(m.Value);    
    // Match m1 = Regex.Match("Amount: 50000",@"\d*");
    // Console.WriteLine(m1.Value);    
    // MatchCollection matches=Regex.Matches("10A20B30C",@"\D");
    // foreach(Match i in matches)
    // Console.WriteLine(i.Value);
    // MatchCollection ma=Regex.Matches("10A20B30C!@_abc",@"\w");
    // string sentence="10A20B30C!@_abc    01\t";
    // string pattern2=@"\W";
    // string sentence="Hello10A20B30C?!@_abc \t,c:\\abc\\file.txt?";
    // string sentence="Date: 2025-12-29";
    // string pattern2=@"\s";
    // string pattern2=@"\.txt";
    // string pattern2=@"\\";
    // string pattern2=@"\\";
    // string pattern2=@"^ lo";
    // string pattern2=@"(\d{4}-(\d{2})-(\d{2}))";
    // string sentence="Amount:5000";
    // string pattern2=@"Amount:(?<value>\d\d+)";
    // string pattern2=@"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";
    // string sentence="23-02-1992";
    // string sentence="1992-02-23,1990-01-01";
    // Match m = Regex.Match(sentence,pattern2);
    // MatchCollection ma=Regex.Matches(sentence,pattern2);
    // Console.WriteLine("Match : "+m.Value);
    // Console.WriteLine("Match : "+(m.Groups["year"].Value));
    // Console.WriteLine("Match : "+m.Groups["month"].Value);
    // Console.WriteLine("Match : "+ma.Groups["year"].Value);
    // Console.WriteLine("Match : "+ma.Groups["month"].Value);
        

    // foreach(Match i in ma)
    // Console.WriteLine("Matches : "+i.Groups["month"].Value);
    // string Pattern = @"Amount=(?<value>\d+)";

    // string Pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";
    // // string Input = "23-02-1992";
    // // string Input = "1992-02-23, 1990-01-01";
    // // string Input = "1992/02/23, 1990-01-01";
    // string Input = "1992-02-23, 1990-01-01, 2025";

    // Match m = Regex.Match(input, pattern);
    // Matchcollection m2 = Regex.Matches(input, pattern);
    // foreach (Match x in m2 ){

    // Console.WriteLine(m.Groups["year"].Value);
    // Console.WriteLine(m.Groups["month"].Value);
    
    List<string> Emails = new List<string>
{
    "john.doe@gmail.com",
    "alice_123@yahoo.in",
    "mark.smith@company.com",
    "support-abc@banking.co.in",
    "user.nametag@domain.org",
  "john.doe@gmail",          // Missing domain extension
    "alice@@yahoo.com",        // Double @
    "mark.smith@.com",         // Domain missing name
    "support@banking..com",    // Double dot in domain
    "user name@gmail.com",     // Space not allowed
    "@domain.com",             // Missing username
    "admin@domain",            // No top-level domain
    "info@domain,com",         // Comma instead of dot
    "finance#dept@corp.com",   // Invalid character #
    "plainaddress"    ,         // Missing @ and domain
    "admin.lpu.co.in",
    "admin@lpu.in",
"admin@lpu.co.in",
"user@company.com",
"support@bank.gov.in",
"info@domain.com.au"

};
    string pattern=@"\b[\w.-]+@[\w]+\.\w{2,}\b";                                                                                                                                                                                                                                                                                                                                                  +@[\w.-]+(\.\w{2,})+\b";
    foreach (string email in Emails)
        {
            if (Regex.IsMatch(email, pattern))
            {
                Console.WriteLine($"VALID   : {email}");
            }
            else
            {
                Console.WriteLine($"INVALID : {email}");
            }

    }
    }
}
