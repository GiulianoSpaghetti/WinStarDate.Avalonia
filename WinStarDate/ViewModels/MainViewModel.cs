using System.IO;
using System;
using WinDateFrom;
using DynamicData.Kernel;

namespace WinStarDate.ViewModels;

public class MainViewModel : ViewModelBase
{
    private static Opzioni o;
    public static readonly string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    public static void CaricaOpzioni()
    {
        LeggiOpzioni(path);
    }
    private static void LeggiOpzioni(String folder)
    {
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);
        StreamReader file;
        try
        {
            file = new StreamReader(folder + "opzioni.json");
        }
        catch (FileNotFoundException ex)
        {
            DateTime d = DateTime.Now;
            o = new Opzioni();
            o.day = d.Day;
            o.month = d.Month;
            o.year = d.Year;
            return;
        }
        string s = file.ReadToEnd();
        file.Close();
        o = Newtonsoft.Json.JsonConvert.DeserializeObject<Opzioni>(s);
        if (o==null)
        { 
            DateTime d = DateTime.Now;
            o = new Opzioni();
            o.day = d.Day;
            o.month = d.Month;
            o.year = d.Year;
            return;

        }
    }

    public static bool SalvaOpzioni(String folder, int d, int m, int y)
    {
        if (d < 0 || m < 0 || y < 0)
            return false;
        o.day = d;
        o.month = m;
        o.year = y;
        StreamWriter w = new StreamWriter(folder + "opzioni.json");
        w.Write(Newtonsoft.Json.JsonConvert.SerializeObject(o));
        w.Close();
        return true;
    }

    public static int GetGiorno() { return o.day; }
    public static int GetMese() { return o.month; }
    public static int GetAnno() { return o.year; }
    public static String calcola(DateTimeOffset? d)
    {
        DateTime data = ((DateTimeOffset) d).UtcDateTime.ToUniversalTime();
        int i = int.Parse(data.ToString("dd"));
        String s;
        if (i < 10)
            s = $"0{i}";
        else
            s = $"{i}";
       return $"{data.ToString("yy")}{data.ToString("MM")}.{s}";
    }
}
