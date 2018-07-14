using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

public class Example
{
   public static void Main()
   {
      string[] args = Environment.GetCommandLineArgs();
      if (args.Length > 1)
         GetPageSizeAsync(args[1]).Wait();//This is being done because it is in the Main() method, which cannot be modified with async
      else
         Console.WriteLine("Enter at least one URL on the command line.");
   }

   private static async Task GetPageSizeAsync(string url)  
   {  
       var client = new HttpClient();  
       var uri = new Uri(Uri.EscapeUriString(url));
       byte[] urlContents = await client.GetByteArrayAsync(uri);
       Console.WriteLine($"{url}: {urlContents.Length/2:N0} characters");  
   }  
}
// The following call from the command line:
//    PS D:\Visual Studio\Projects\c_sharp\cSharpGuide_docs.microsoft.com\operators\await> dotnet run http://docs.microsoft.com
//    http://docs.microsoft.com: 9 078 characters
//    PS D:\Visual Studio\Projects\c_sharp\cSharpGuide_docs.microsoft.com\operators\await> dotnet run http://docs.microsoft.com
//    http://docs.microsoft.com: 9 078 characters