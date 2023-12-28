internal class Program
{
    private static void Main(string[] args)
    {
        Kadro k1 = new Kadro(bolum.ArGe,"Mehmet");
        Yazilim leyla = new Yazilim(bolum.Senior,"Leyla");
        Yazilim Mustafa = new Yazilim(bolum.Senior, "Mustafa");
        Yazilim Beyza= new Yazilim(bolum.Senior, "Beyza");
        k1.ekle(leyla);
        k1.ekle(Beyza);
        k1.ekle(Mustafa);

        k1.Yazdir(1);


    }
}

enum bolum
{
   ArGe,Analist,Test,Senior,Junior
}


abstract class Sirket//component
{
    private bolum departman;
    private string isim;

    protected Sirket(bolum departman, string isim)
    {
        Departman = departman;
        Isim = isim;
    }

    public bolum Departman { get => departman; set => departman = value; }
    public string Isim { get => isim; set => isim = value; }

    public abstract void ekle(Sirket ys);
    public abstract void sil(Sirket ys);
    public abstract void Yazdir(int SatirBasi);
}

class Kadro : Sirket//composite
{

    private List<Sirket> kadroliste=new List<Sirket>();



    public Kadro(bolum departman, string isim) : base(departman, isim)
    {
    }

    public override void ekle(Sirket ys)
    {
        kadroliste.Add(ys);
    }

    public override void sil(Sirket ys)
    {
       kadroliste.Remove(ys);
    }

    public override void Yazdir(int SatirBasi)
    {
        Console.WriteLine(new string('-', SatirBasi) + ">" + Isim + "-" + Departman);
        foreach (Sirket u in kadroliste) {
            u.Yazdir(SatirBasi+2);
        }


    }
}

class Yazilim : Sirket//leaff
{
    public Yazilim(bolum departman, string isim) : base(departman, isim)
    {
    }

    public override void ekle(Sirket ys){}

    public override void sil(Sirket ys){}

    public override void Yazdir(int SatirBasi)
    {
        Console.WriteLine(new string('-',SatirBasi)+">"+Isim+"-"+Departman);
    }
}