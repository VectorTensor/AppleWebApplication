using Microsoft.AspNetCore.Components.Forms;

namespace Apple.Services;

public static class AMa
{

    public static string UpperCase(this string s, int x)
    {

        
        return char.ToUpper(s[0]) + s.Substring(1) + x.ToString();


    }
    
}