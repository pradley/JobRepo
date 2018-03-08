using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSite.Buisness_Logic
{
    public class WigetUtility
    {

        public string ReverseString(string input)
        {
          return  input = new string(Enumerable.Range(1, input.Length).Select(i => input[input.Length - i]).ToArray());
        }

        public string SumEvenNumbers(string list)
        {
            //TODO
            //If the list is not comma seprated alert the user and ask for a comma seperated list 

            int number;
            var answer=list.Split(',')
                .Where(n => int.TryParse(n, out number)&& number % 2 ==0)
                .Select(s => s)
                .Sum(w => Convert.ToInt64(w)).ToString();

            return answer;
             
        }

        //public bool IsAnagram
    }
}