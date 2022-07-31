using System.Collections.Generic;
using System.Reflection;

namespace ListAllCultures
{
  public class NamePropertyComparer<T> : IComparer<T>
  {
    public int Compare(T x, T y)
    {
      if (x == null)
        if (y == null)
          return 0;
        else
          return -1;

      PropertyInfo pX = x.GetType().GetProperty("Name");
      PropertyInfo pY = y.GetType().GetProperty("Name");
      return string.Compare((string)pX.GetValue(x, null), (string)pY.GetValue(y, null));
    }
  }

}