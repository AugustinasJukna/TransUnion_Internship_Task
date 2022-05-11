﻿using System;

namespace TransUnion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                List<Temperature> TemperatureList = new List<Temperature>();
                TemperatureList.Add(new Temperature("Celsius"));
                TemperatureList.Add(new Temperature("Kelvin"));
                TemperatureList.Add(new Temperature("Fahrenheit"));
                TemperatureList.Add(new Temperature("Rømer", "(R - 7.5) / (0.52500)", "C * 0.52500 + 7.5")); //This way new temperatures can easily be added
                Console.WriteLine("Sveiki! (Spauskite CRTL-C norėdami sustabdyti programos veikimą)");
                Console.WriteLine("Pasirinkite pradinės temperatūros numerį:");
                for (int i = 0; i < TemperatureList.Count - 1; i += 2)
                {
                    Console.WriteLine(String.Format("{0}.{1, -15}  {2}.{3, -15}", i + 1, TemperatureList[i].Name, i + 2, TemperatureList[i + 1].Name));
                }
                int caseNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Įveskite temperatūrą: ");
                double value = double.Parse(Console.ReadLine());
                Temperature currentInputTemperature;
                TemperatureList[caseNumber - 1].Value = value;
                currentInputTemperature = TemperatureList[caseNumber - 1];
                Console.WriteLine("Į kurią temperatūrą norite paversti?");
                for (int i = 0; i < TemperatureList.Count - 1; i += 2)
                {
                    Console.WriteLine(String.Format("{0}.{1, -15}  {2}.{3, -15}", i + 1, TemperatureList[i].Name, i + 2, TemperatureList[i + 1].Name));
                }
                caseNumber = int.Parse(Console.ReadLine());
                Console.WriteLine("Gaunama: " + Temperature.CallMethodByTemperature(currentInputTemperature, TemperatureList[caseNumber - 1]));
                Console.WriteLine();
            }
        }
    }
}