using System;
using WebApplication.Services.Abstract;

namespace WebApplication.Services.Concrete
{
    public class StringService: IStringService
    {
        public bool IsPalindrome(string value) { 
            var arr = value.ToCharArray();
            Array.Reverse(arr);
            var result = new string(arr);

            return result == value;
        }

        public string ReverseWords(string value)
        {
            var arr = value.Split(" ");
            Array.Reverse(arr);
            var result = String.Join(" ", arr);

            return result;
        }
    }
}
