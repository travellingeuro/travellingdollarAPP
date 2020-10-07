using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace travellingdollar.Helper
{
    class Checkvalue
    {

        private string message;
        public string Message { get => message; set => message = value; }

        public bool Checknumber(string serial)
        {
            if (serial is null)
            {
                Message = "Serial number cannot be empty";
                return false;
            }

            if (serial.Length != 11 && serial.Length!=10)
            {
                Message = "Serial Number must be 10 or 11 characters long and it must begin with a letter";
                return false;
            }

            if (!Checkfirstletter(serial))
            {
                Message = "Serial Number must begin with a letter";
                return false;
            }

            if (!Isfirstlettervalid(serial.ToUpper()))
            {
                Message = "Not a valid initial letter";
                return false;
            }
            if (!Islastlettervalid(serial))
            {
                Message = "Don't forget to include the last letter";
                return false;
            }
            if (!Isnumbervalid(serial))
            {
                Message = "Not a valid serial number. Check it again";
                return false;
            }
            return true;
        }

        public bool Checkfirstletter(string serial)
        {
            char firstletter = serial.ToCharArray().ElementAt(0);
            return char.IsLetter(firstletter) ? true : false;
        }

        public bool Isfirstlettervalid(string serial)
        {
            //Mints code for the first or second letter
            Dictionary<char, int> mints = new Dictionary<char, int>()
                                            {
                                            {'A',1},{'B',2 } ,{'C',3},{'D',4}, {'E',5},{'F',6},
                                            {'G',7},{'H',8},{'I',9},{'J',10},{'K',11},
                                            {'L',12}
                                            };
            //Year Series code
            Dictionary<char, int> series = new Dictionary<char, int>()
                                            {   
                                            {'A',1996},{'B',1999 } ,{'C',2001},{'D',2003}, {'E',2004},{'F',2003},
                                            {'G',2004},{'I',2006},{'J',2009},{'K',2006},{'L',2009},
                                            {'M',2013},{'N',2017} 
                                            };
            //store the first two characters of the bill
            var first = serial.ToUpper().ToCharArray().ElementAt(0);
            var second = serial.ToUpper().ToCharArray().ElementAt(1);

            //Case starts with one letter only (it's a 1 or 2 dollar bill)- Letter must be in the mints dictionary
            if(char.IsLetter(first) && char.IsDigit(second))
            {
                return mints.ContainsKey(first) ? true : false;
            }
            //Case starts with two letters. First must be in series dict and second in mints dict
            if (char.IsLetter(first)&& char.IsLetter(second))
            {
                return series.ContainsKey(first) && mints.ContainsKey(second) ? true : false; 

            }

            return false;
        }

        public bool Islastlettervalid(string serial)
        {
            char lastletter = serial.ToCharArray().Last();
            return char.IsLetter(lastletter) ? true : false;
        }

        public bool Isnumbervalid(string serial)
        {
            //strip the last letter
            var s = serial.Remove(serial.Length-1,1);

            //get the last 8 positions 
            var serialnumbers = s.Substring(s.Length - 8);
            //convert to number is posible
            int numbers;
            if(!int.TryParse(serialnumbers, out numbers))
            {
                return false;
            }

            //Check values are between  00000001 and 99840000

            return numbers <= 99840000;

        }
    }
}
