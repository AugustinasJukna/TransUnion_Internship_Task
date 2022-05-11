using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransUnion
{
    public class Temperature
    {
        public string Name { get; set; }
        public double Value { get; set; }

        public string? FormulaToC { get; set; } //Formulas should be in a format that is similar to this: "E * 100 + 100.75" or "(E - 100) / 5.25" (no duplicate operators)
        public string? FormulaFromC { get; set; }


        public Temperature(string name, string formula1, string formula2)
        {
            Name = name;
            FormulaToC = formula1;
            FormulaFromC = formula2;
        }

        public Temperature(string name)
        {
            Name = name;
        }

        public double ConvertToCelsius()
        {
            if (Name.ToUpper() == "KELVIN")
            {
                return this.Value - 273.15;
            }
            else if (Name.ToUpper() == "FAHRENHEIT")
            {
                return (this.Value - 32) * 5 / 9;
            }
            else if (Name.ToUpper() == "CELSIUS") return this.Value;
            else //If a custom temperature scale has been added (reads the formula)
            {
                string[] Parts = FormulaToC.Split(new char[] {'+', '*', ' ', '(', ')', '/', '-'}, StringSplitOptions.RemoveEmptyEntries);
                if (FormulaToC.IndexOf('*') < FormulaToC.IndexOf('+') && FormulaToC.IndexOf('*') >= 0 && FormulaToC.IndexOf('+') >= 0)
                {
                    double celsius = this.Value * double.Parse(Parts[1]);
                    celsius += double.Parse(Parts[2]);
                    return celsius;
                }
                if (FormulaToC.IndexOf('*') < FormulaToC.IndexOf('-') && FormulaToC.IndexOf('*') >= 0 && FormulaToC.IndexOf('-') >= 0)
                {
                    double celsius = this.Value * double.Parse(Parts[1]);
                    celsius -= double.Parse(Parts[2]);
                    return celsius;
                }
                else if (FormulaToC.IndexOf('/') < (FormulaToC.IndexOf('+')) && FormulaToC.IndexOf('/') >= 0 && FormulaToC.IndexOf('+') >= 0) 
                {
                    double celsius = this.Value / double.Parse(Parts[1]);
                    celsius += double.Parse(Parts[2]);
                    return celsius;
                }
                else if (FormulaToC.IndexOf('/') < (FormulaToC.IndexOf('-')) && FormulaToC.IndexOf('/') >= 0 && FormulaToC.IndexOf('-') >= 0)
                {
                    double celsius = this.Value / double.Parse(Parts[1]);
                    celsius -= double.Parse(Parts[2]);
                    return celsius;
                }
                else if (FormulaToC.IndexOf('-') < FormulaToC.IndexOf('*') && FormulaToC.IndexOf('-') >= 0 && FormulaToC.IndexOf('*') >= 0)
                {
                    double celsius = this.Value - double.Parse(Parts[1]);
                    celsius *= double.Parse(Parts[2]);
                    return celsius;
                }
                else if (FormulaToC.IndexOf('+') < FormulaToC.IndexOf('*') && FormulaToC.IndexOf('+') >= 0 && FormulaToC.IndexOf('*') >= 0)
                {
                    double celsius = this.Value + double.Parse(Parts[1]);
                    celsius *= double.Parse(Parts[2]);
                    return celsius;
                }
                else if (FormulaToC.IndexOf('-') < FormulaToC.IndexOf('/') && FormulaToC.IndexOf('-') >= 0 && FormulaToC.IndexOf('/') >= 0)
                {
                    double celsius = this.Value - double.Parse(Parts[1]);
                    celsius /= double.Parse(Parts[2]);
                    return celsius;
                }
                else
                {
                    double celsius = this.Value + double.Parse(Parts[1]);
                    celsius /= double.Parse(Parts[2]);
                    return celsius;
                }
            }
        }

        public double ConvertToKelvin()
        {
            if (Name.ToUpper() == "CELSIUS")
            {
                return this.Value + 273.15;
            }
            else if (Name.ToUpper() == "FAHRENHEIT")
            {
                return (this.Value - 32) * 5 / 9 + 273.15;
            }
            else if (Name.ToUpper() == "KELVIN") return this.Value;
            else //If a custom temperature scale has been added (reads the formula)
            {
                double convertedToC = ConvertToCelsius();
                return convertedToC + 273.15;
            }
        }

        public double ConvertToFahrenheit()
        {
            if (Name.ToUpper() == "CELSIUS")
            {
                return this.Value * 9 / 5 + 32;
            }
            else if (Name.ToUpper() == "KELVIN")
            {
                return (this.Value - 273.15) * 9 / 5  + 32;
            }
            else if (Name.ToUpper() == "FAHRENHEIT") return this.Value;
            else //If a custom temperature scale has been added
            {
                double convertedToC = ConvertToCelsius();
                return convertedToC * 9 / 5 + 32;
            }
        }

        public static double CallMethodByTemperature(Temperature input, Temperature convertTo)
        {
            switch(convertTo.Name.ToUpper())
            {
                case "CELSIUS":
                    return input.ConvertToCelsius();
                    break;
                case "FAHRENHEIT":
                    return input.ConvertToFahrenheit();
                    break;
                case "KELVIN":
                    return input.ConvertToKelvin();
                    break;
            }
            //If a custom temperature scale has been added (reads the formula)
            string[] Parts = convertTo.FormulaFromC.Split(new char[] { '+', '*', ' ', '(', ')', '/', '-' }, StringSplitOptions.RemoveEmptyEntries);
            if (convertTo.FormulaFromC.IndexOf('*') < convertTo.FormulaFromC.IndexOf('+') && convertTo.FormulaFromC.IndexOf('*') >= 0 && convertTo.FormulaFromC.IndexOf('+') >= 0)
            {
                double value = input.ConvertToCelsius() * double.Parse(Parts[1]);
                value += double.Parse(Parts[2]);
                return value;
            }
            if (convertTo.FormulaFromC.IndexOf('*') < convertTo.FormulaFromC.IndexOf('-') && convertTo.FormulaFromC.IndexOf('*') >= 0 && convertTo.FormulaFromC.IndexOf('-') >= 0)
            {
                double value = input.ConvertToCelsius() * double.Parse(Parts[1]);
                value -= double.Parse(Parts[2]);
                return value;
            }
            else if (convertTo.FormulaFromC.IndexOf('/') < (convertTo.FormulaFromC.IndexOf('+')) && convertTo.FormulaFromC.IndexOf('/') >= 0 && convertTo.FormulaFromC.IndexOf('+') >= 0)
            {
                double value = input.ConvertToCelsius() / double.Parse(Parts[1]);
                value += double.Parse(Parts[2]);
                return value;
            }
            else if (convertTo.FormulaFromC.IndexOf('/') < (convertTo.FormulaFromC.IndexOf('-')) && convertTo.FormulaFromC.IndexOf('/') >= 0 && convertTo.FormulaFromC.IndexOf('-') >= 0)
            {
                double value = input.ConvertToCelsius() / double.Parse(Parts[1]);
                value -= double.Parse(Parts[2]);
                return value;
            }
            else if (convertTo.FormulaFromC.IndexOf('-') < convertTo.FormulaFromC.IndexOf('*') && convertTo.FormulaFromC.IndexOf('-') >= 0 && convertTo.FormulaFromC.IndexOf('*') >= 0)
            {
                double value = input.ConvertToCelsius() - double.Parse(Parts[1]);
                value *= double.Parse(Parts[2]);
                return value;
            }
            else if (convertTo.FormulaFromC.IndexOf('+') < convertTo.FormulaFromC.IndexOf('*') && convertTo.FormulaFromC.IndexOf('+') >= 0 && convertTo.FormulaFromC.IndexOf('*') >= 0)
            {
                double value = input.ConvertToCelsius() + double.Parse(Parts[1]);
                value *= double.Parse(Parts[2]);
                return value;
            }
            else if (convertTo.FormulaFromC.IndexOf('-') < convertTo.FormulaFromC.IndexOf('/') && convertTo.FormulaFromC.IndexOf('-') >= 0 && convertTo.FormulaFromC.IndexOf('/') >= 0)
            {
                double value = input.ConvertToCelsius() - double.Parse(Parts[1]);
                value /= double.Parse(Parts[2]);
                return value;
            }
            else
            {
                double value = input.ConvertToCelsius() + double.Parse(Parts[1]);
                value /= double.Parse(Parts[2]);
                return value;
            }
        }

    }
}
