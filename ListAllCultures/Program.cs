using System;
using System.Globalization;

namespace ListAllCultures
{
  internal class Program
  {
    static void Main()
    {
      Action<string> Display = Console.WriteLine;
      //Console.SetWindowSize(240, 94);
      // Display the header.
      Console.WriteLine("{0,-53}{1}", "CULTURE", "SPECIFIC CULTURE");

      // Get each neutral culture in the .NET Framework.
      CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
      // Sort the returned array by name.
      Array.Sort<CultureInfo>(cultures, new NamePropertyComparer<CultureInfo>());

      // Determine the specific culture associated with each neutral culture.
      foreach (var culture in cultures)
      {
        Console.Write("{0,-12} {1,-40}", culture.Name, culture.EnglishName);
        try
        {
          Console.WriteLine("{0}", CultureInfo.CreateSpecificCulture(culture.Name).Name);
        }
        catch (ArgumentException)
        {
          Display("(no associated specific culture)");
        }
      }

      Display("press any key to exit:");
      Console.ReadKey();
    }
  }
}
