using DalList;
using System.Linq;

namespace BL
{
    public class Reverse
    {
        public List<string> ReverseList()
        {
            Namerep repo = new Namerep();
            List<string> listt = repo.ListNames();

            return listt
                .Select(x => new string(x.Reverse().ToArray()))
                .ToList();

            // foreach (var item in reversedList)
            // {
            //     Console.WriteLine(item);
            // }
            // return reversedList;
        }
    }
}
