using Microsoft.AspNetCore.WebUtilities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using PracticeMVC.Models;
using System.Text;


namespace PracticeMVC.Models
{
    public class TextContract
    {

        // purpose - to mediate the interactions between objects. eg the webiste takes in a valid input, but this text needs cleaned so it can be put in the binary tree object.
        //this seems like something for a 'contract' - role to set rules of collaboration and transform data.
        public List<string> CleanString(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
                return new List<string>();

            var stringbuilder = new StringBuilder();

            foreach (char c in inputText)
            {
                if (char.IsLetter(c) || c == '&')
                {
                    stringbuilder.Append(c);
                }
                else
                {
                    stringbuilder.Append(',');
                }

            }

            List<string> textBody = stringbuilder.ToString().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(word => word.Trim().ToLower()).Where(word => word.Length > 0).ToList();


            return textBody;

            //https://learn.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split

        }



    }
}
