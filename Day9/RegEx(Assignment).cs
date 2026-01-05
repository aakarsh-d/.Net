// Log Analysis Utility Using Regular Expressions in C#

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace LogProcessing
{
    class LogParser
    {
        private readonly string validLineRegexPattern;
        private readonly string splitLineRegexPattern;
        private readonly string quotedPasswordRegexPattern;
        private readonly string endOfLineRegexPattern;
        private readonly string weakPasswordRegexPattern;
        
        public LogParser()
        {
            validLineRegexPattern=@"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
            splitLineRegexPattern=@"<\*\*\*>|<====>|<\^\*>";
            // splitLineRegexPattern=@"<[\^*=]>";
            quotedPasswordRegexPattern="[^\"]*password[^\"]*";
            endOfLineRegexPattern=@"end-of-line\d+";
            weakPasswordRegexPattern=@"^password[\w]";
        }

        public bool isValidLine(string text){
            Match m=Regex.IsMatch(validLineRegexPattern, text);
            if(m) return true;
            
            return false;
            
        }

        public string[] SplitLine(string text)
        {
            return Regex.Split(text, splitLineRegexPattern);
        }
        public int CountQuotedPasswords(string lines)
        {
            return Regex.Matches(lines,quotedPasswordRegexPattern, RegexOptions.IgnoreCase).Count;
        }

        public string RemoveEndOfLineText(string line)
        {
            return Regex.Replace(line,endOfLineRegexPattern,"").Trim();

        }

        public string[] ListLinesWithPasswords(string[] lines)
        {
            string[] res=new string[lines.Length];

            for(int i = 0; i < lines.Length; i++)
            {
                Match ma= Regex.Match(lines[i],weakPasswordRegexPattern,RegexOptions.IgnoreCase);

                if(ma.Success) res[i]=ma.Value+": "+lines[i];

                else res[i]="-------; " +lines[i];
            }
            return res;
        }
    public static void Main()
        {
            Console.WriteLine("Task 1: Validate Log Lines");
            string log1="[INF] Application started";
            string log2="INFO Application started";

            Console.WriteLine($"{log1} -> {IsValidLine(log1)}");
            Console.WriteLine($"{log2} -> {IsValid(log2)}");
            Console.WriteLine();


            Console.WriteLine("Task 2: Split Log Line");
            string splitLog="User<***>Login<====>Success<^*>Done";
            string[] parts=SplitLine(splitLog);
            
            foreach(string line in parts)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine();


            Console.WriteLine("Task 3: Count Quoted Password");
            string multiLineLogs="User entered \"password123\"\n"+ "Another Entry \"PASSWORD456\"\n"+"No password here";

            int count=CountQuotedPasswords(multiLineLogs);
            Console.WriteLine($"Quoted Password Count");

            Console.WriteLine("Task 4:")
        }
    }
}



