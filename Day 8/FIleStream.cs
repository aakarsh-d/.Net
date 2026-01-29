// class Program 
// {
//     public static void Main(string[] args)
//     {FileStream file=null;
//     try{
//         file=new FileStream("data.txt",FileMode.Open);
        
//         int data=file.ReadByte();
//         Console.WriteLine("Dataa:   "+ data);

//     }
//     catch(FileNotFoundException ex){
//         Console.WriteLine("File not found: "+ex.Message);
//     }
//     finally{
//         if(file!=null){
//             file.Close();
//             Console.WriteLine("File stream Close in Finally block.");
//         }
//     }}
// }