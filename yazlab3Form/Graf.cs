using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazlab3
{
    class Sonuc
    {
       public List<Vana> sonuc { get; set; }
        public int sonuckapasite { get; set; }
    }
    class yol
    {
        public yol()
        {
            this.icerdigiyollar = new List<int>();
            this.yolunKullandigi = 0;
        }
        public string yolpath { get; set; }
        public int yolunKullandigi { get; set; }
        public int yolunKapasitesi { get; set; }
        public List<int> icerdigiyollar { get; set; }
    }
    class Graf
    {
        static public List<List<Vana>> Bfs(Vana baslangic, Vana bitis, List<Vana> gidilenVanalar, List<List<Vana>> tumsonuclar,int baslangickontrol)
        {
            List<List<Vana>> yerelsonuc;
            foreach (var Komsu in baslangic.komsular)
            {
                if (gidilenVanalar.IndexOf(Komsu.komsu) != -1)
                    continue;
                if (Komsu.komsu.Equals(bitis))
                {
                    gidilenVanalar.Add(bitis);
                    tumsonuclar.Add(gidilenVanalar.Select(item => item).ToList());
                    gidilenVanalar.Remove(bitis);
                    continue;
                }
                List<Vana> YenigidilenVanalar = gidilenVanalar.Select(item => item).ToList();
                YenigidilenVanalar.Add(Komsu.komsu);
                Bfs(Komsu.komsu, bitis, YenigidilenVanalar, tumsonuclar,0);
            }
            return tumsonuclar;
        }
        static public List<List<Vana>> SiralaVeDuzelt(List<List<Vana>> tumsonuclar)
        {
            List<List<Vana>> temp = new List<List<Vana>>();
            List<Vana> a;
            for (int i = 0; i < tumsonuclar.Count; ++i)
            {

                for (int j = i + 1; j < tumsonuclar.Count; ++j)
                {

                    if (tumsonuclar[i].Count > tumsonuclar[j].Count)
                    {

                        a = tumsonuclar[i];
                        tumsonuclar[i] = tumsonuclar[j];
                        tumsonuclar[j] = a;

                    }

                }
            }
            for (int i = tumsonuclar.Count - 1; i >= 0; i++)
            {
                temp.Clear();
                for (int j = 0; j < tumsonuclar[i].Count - 1; j++)
                {
                    temp.Add(new List<Vana>());
                    temp[(temp.Count) - 1].Add(tumsonuclar[i][j]);
                    temp[(temp.Count) - 1].Add(tumsonuclar[i][j + 1]);

                }
                for (int k = 0; k < tumsonuclar.Count; k++)
                {
                    int kontrol1 = 0;
                    if (k == i)
                    {
                        return tumsonuclar;
                    }

                    for (int z = 0; z < tumsonuclar[k].Count - 1; z++)
                    {
                        kontrol1 = 0;
                        foreach (var degisken in temp)
                        {
                            if (degisken[0].ismi == tumsonuclar[k][z + 1].ismi && degisken[1].ismi == tumsonuclar[k][z].ismi)
                            {
                                kontrol1 = 1;
                                break;
                            }
                        }
                        if (kontrol1 == 1)
                        {
                            tumsonuclar.RemoveAt(i);
                            i = tumsonuclar.Count - 2;
                            break;
                        }
                    }
                    if (kontrol1 == 1)
                    {
                        break;
                    }

                }
            }
            return tumsonuclar;
        }
      static public List<Sonuc> Maxflow(List<List<Vana>> tumsonuclar)
       {
            List<Sonuc> butunSonuclar = new List<Sonuc>();
            int kontrolbit = 0;
          foreach(var result in tumsonuclar)
            {
                kontrolbit = 0;
                int min = result[0].komsular[KomsuindexBul(result[0], result[1].ismi)].kapasite - result[0].komsular[KomsuindexBul(result[0], result[1].ismi)].doluluk;
                if(min <= 0)
                {
                    continue;
                }
              for(int i = 0; i < result.Count-1; i++)
                {
                    if (result[i].komsular[KomsuindexBul(result[i], result[i+1].ismi)].kapasite
                        - result[i].komsular[KomsuindexBul(result[i], result[i + 1].ismi)].doluluk< min)
                    {
                        min = result[i].komsular[KomsuindexBul(result[i], result[i + 1].ismi)].kapasite- result[i].komsular[KomsuindexBul(result[i], result[i + 1].ismi)].doluluk;
                        if (min <= 0)
                        {
                            kontrolbit = 1;
                            break;
                        }
                    }
                }
                if (kontrolbit == 1)
                {
                    continue;
                }
                for (int i = 0; i < result.Count - 1; i++)
                {
                    
                    if(result[i].komsular[KomsuindexBul(result[i], result[i + 1].ismi)].doluluk+min > result[i].komsular[KomsuindexBul(result[i], result[i + 1].ismi)].kapasite)
                    {
                        kontrolbit = 1;
                        break;
                    }
               
                }
                if(kontrolbit == 1)
                {
                    
                    
                    continue;
                }
                else
                {
                    for (int i = 0; i < result.Count - 1; i++)
                    {
                        result[i].komsular[KomsuindexBul(result[i], result[i + 1].ismi)].doluluk += min;

                    }
                    butunSonuclar.Add(new Sonuc());
                    butunSonuclar[(butunSonuclar.Count) - 1].sonuc = result;
                    butunSonuclar[(butunSonuclar.Count) - 1].sonuckapasite = min;
                }

            }

            return butunSonuclar;
        }
        static public List<List<yol>> Mincut (List<Sonuc> tumsonuclar)
        {
            if (tumsonuclar.Count == 0)
                return null;
            int toplamAkansu = 0;
            
            List<yol> yollar = new List<yol>();
            int count = 0;
            foreach(var result in tumsonuclar)
            {
                for(int i = 0; i<result.sonuc.Count-1; i ++)
                {
                    if (YolindexBul(yollar, result.sonuc[i].ismi +" "+ result.sonuc[i + 1].ismi) == -1)
                    {
                        yollar.Add(new yol());
                        yollar[yollar.Count - 1].yolpath = result.sonuc[i].ismi + " "+ result.sonuc[i + 1].ismi;
                        yollar[yollar.Count - 1].yolunKullandigi = result.sonuckapasite;
                        yollar[yollar.Count - 1].yolunKapasitesi = result.sonuc[i].komsular[KomsuindexBul(result.sonuc[i], result.sonuc[i + 1].ismi)].kapasite;
                        yollar[yollar.Count - 1].icerdigiyollar.Add(count);
                    }
                    else {
                        yollar[YolindexBul(yollar, result.sonuc[i].ismi +" "+result.sonuc[i + 1].ismi)].yolunKullandigi += result.sonuckapasite;
                        yollar[YolindexBul(yollar, result.sonuc[i].ismi +" "+ result.sonuc[i + 1].ismi)].icerdigiyollar.Add(count);

                            }
                }
                count++;
                toplamAkansu += result.sonuckapasite;
            }
            yol a;
           for(int i =0;i< yollar.Count; i++)
            {
                for(int j = i+1; j < yollar.Count; j++)
                {
                    if(yollar[i].icerdigiyollar.Count > yollar[j].icerdigiyollar.Count)
                    {
                        a = yollar[i];
                        yollar[i] = yollar[j];
                        yollar[j] = a;
                    }
                }
            }
            List<List<yol>> yeniYollar = new List<List<yol>>();
            int kontrolbiti=0;
            int kontrolbiti2 = 0;
            for (int i = yollar.Count-1; i >= 0; i--)
            {
               
                int toplamkullanilan1=0;
                toplamkullanilan1 = 0;
                if (kontrolbiti2 == 1)
                {
                    foreach (var degisken in yeniYollar[yeniYollar.Count - 1])
                    {
                        toplamkullanilan1 += degisken.yolunKullandigi;
                    }
                    if (toplamkullanilan1 != toplamAkansu)
                    {
                        yeniYollar.RemoveAt(yeniYollar.Count - 1);
                    }
                }
                yeniYollar.Add(new List<yol>());
                kontrolbiti2 = 1;
                yeniYollar[yeniYollar.Count - 1].Add(yollar[i]);
                kontrolbiti = 0;
                for(int j= i-1; j >= 0; j--)
                {
                    kontrolbiti = 0;
                    foreach(var road in yollar[i].icerdigiyollar)
                    {
                        if(yollar[j].icerdigiyollar.IndexOf(road) != -1)
                        {
                            kontrolbiti = 1;
                            break;
                        }
                        
                    }
                    if(kontrolbiti == 1)
                    {
                        continue;
                    }
                    else
                    {
                        int kontrol2 = 0;
                        int sayac = 0;
                        if ((yollar[j].icerdigiyollar.Count == 1))
                        {
                            kontrol2 = 0;
                            for(int index =0;index<yeniYollar[yeniYollar.Count - 1].Count;index++)
                            {
                                var road = yeniYollar[yeniYollar.Count - 1][index];
                                if ((road.icerdigiyollar.Count) == 1)
                                {
                                    if (road.icerdigiyollar.IndexOf(yollar[j].icerdigiyollar[0]) != -1)
                                    {
                                        kontrol2 = 1;
                                        if (yeniYollar[yeniYollar.Count - 1][sayac].yolunKapasitesi > yollar[j].yolunKapasitesi)
                                        {
                                            

                                            yeniYollar[yeniYollar.Count - 1].RemoveAt(sayac);
                                            yeniYollar[yeniYollar.Count - 1].Insert(sayac, yollar[j]);
                                           
                                        }
                                    }
                                   
                                }
                                sayac++;
                            }
                            if (kontrol2 == 0)
                            {
                                yeniYollar[yeniYollar.Count - 1].Add(yollar[j]);
                            }
                        }
                        else { yeniYollar[yeniYollar.Count - 1].Add(yollar[j]); }
                           
                    }
                }
            }
            int toplamkullanilan = 0;
            foreach (var degisken in yeniYollar[yeniYollar.Count - 1])
            {
                toplamkullanilan += degisken.yolunKullandigi;
            }
            if (toplamkullanilan < toplamAkansu)
            {
                yeniYollar.RemoveAt(yeniYollar.Count - 1);
            }
         
            return yeniYollar;
        }
        static public int KomsuindexBul(Vana input,string komsu)
        { int count = 0;
            foreach(var x in input.komsular)
            {
                if (x.komsu.ismi.Equals(komsu))
                {
                    return count;
                }
                count++;
            }
            return -1;
        }
        static public int YolindexBul(List<yol> input, string Yolpath)
        {
            int count = 0;
            foreach (var x in input)
            {
                    if (x.yolpath.
                    Trim().Equals(Yolpath))
                    {
                        return count;
                    }
                
                
                count++;
              
            }
            return -1;
        }
    }
}   