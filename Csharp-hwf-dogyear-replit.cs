// Harald Weedon-Fekjær <haraldwf@weedon-fekjaer.net>, 2021
// Tema:     Bootstrap for binominal proportion thought bootstrap
// Prosjekt: Vise Magnus
// Språk:	 C#, en.wikipedia.org/wiki/C_Sharp_(programming_language)

using System;
using System.Collections.Generic;

public class Program
{

    static int RandBinom(Random rand, double p)
    {
        if (rand.NextDouble() <= p)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    static double RandSumBinom(Random rand, double p, int n)
    {
        int i;
        double sumlist = 0;
        for (i = 1; i <= n; i++)
        {
            sumlist = sumlist + RandBinom(rand, p);
        }
        return sumlist / n;
    }

    public static void Main()
    {
        string obsT;
        Console.Write("Obs: ");
        obsT = Console.ReadLine();
        int obs = Convert.ToInt32(obsT);
        string nT;
        Console.Write("n: ");
        nT = Console.ReadLine();
        int n = Convert.ToInt32(nT);
        //
        double p = Convert.ToDouble(obs) / n;
        int nosim = 1000;
        var rand = new Random(3);
        var Res = new List<double>();
        int i;
        for (i = 1; i <= nosim; i++)
        {
            Res.Add(RandSumBinom(rand, p, n));
        }
        Res.Sort();
        Console.Write(obs + " out of " + n + " gives a proportion of ");
        Console.Write(Math.Round(p, 2));
        double ci1 = Math.Round(Res[Convert.ToInt32(nosim * 0.025)], 2);
        double ci2 = Math.Round(Res[Convert.ToInt32(nosim * 0.975)], 2);
        Console.Write(" [95% CI: " + ci1 + ", " + ci2 + "]\n");
    }
}