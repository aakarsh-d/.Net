<!-- Question 1: Student Attendance Analyzer

A college stores attendance data entered by a staff member as a single line:

101:Present,102:Absent,103:Present,104:,105:Present,ABC:Present,106:Absent

Requirements

Write a C# program that:

Reads the input string.

Parses each entry safely.

Stores valid student attendance in a Dictionary<int, bool?>

Key → Student ID

Value →

true = Present

false = Absent

null = Missing attendance

Ignore invalid IDs (like ABC).

If attendance value is missing (example: 104:), store it as null.

Use StringBuilder to generate the output report.

Output Format
Attendance Report
-----------------
101 -> Present
102 -> Absent
103 -> Present
104 -> Not Marked
105 -> Present
106 -> Absent

Total Present: X
Total Absent: X
Not Marked: X -->