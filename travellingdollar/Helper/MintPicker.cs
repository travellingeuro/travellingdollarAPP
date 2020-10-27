using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace travellingdollar.Helper
{
    public class MintPicker
    {
        public string Name { get; set; }

        public string Picker(int value) 
        {
            switch (value)
            {
                case 1:
                    Name = "Boston";
                    break;
                case 2:
                    Name = "New York";
                    break;
                case 3:
                    Name = "Philadelphia";
                    break;
                case 4:
                    Name = "Cleveland";
                    break;
                case 5:
                    Name = "Richmond";
                    break;
                case 6:
                    Name = "Atlanta";
                    break;
                case 7:
                    Name = "Chicago";
                    break;
                case 8:
                    Name = "St. Louis";
                    break;
                case 9:
                    Name = "Minneapolis";
                    break;
                case 10:
                    Name = "Kansas City";
                    break;
                case 11:
                    Name = "Dallas";
                    break;
                case 12:
                    Name = "San Francisco";
                    break;
                default:
                    Name = "Not Defined";
                    break;
            }
            return Name;
        }
    }
}
