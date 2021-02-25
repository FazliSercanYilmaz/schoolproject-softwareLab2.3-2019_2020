using QuickGraph;
using QuickGraph.Graphviz;
using QuickGraph.Graphviz.Dot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yazlab3;

namespace yazlab3Form
   
{
    class GrafCizdir
    {
        public GrafCizdir()
        {

        }
        AdjacencyGraph<string, TaggedEdge<string, string>> graph { get; set; }
        dotCizimMotoru cizim;

        public void grafYenile()
        {
            this.cizim = new dotCizimMotoru();
            int vanacount = 0;
         foreach (var vana in Nodeolusturucusu.vanalar)
            {
                this.cizim.nodeEkle(vanacount, vana.ismi);
                if (vana.komsular.Count > 0)
                {
                    foreach (var komsu in vana.komsular)
                    {
                        this.cizim.kenarekle(vanacount, Nodeolusturucusu.vanalar.IndexOf(komsu.komsu),komsu.kapasite.ToString());
                   
                    }
                }
                vanacount++;
            }
            
        }
        public  string  grafpngOutput()
        {

            string output = yazdirici(this.cizim.toDot(), "graph");

            return output;
        }
        public void grafGidilenYollarCiz(List<Sonuc> input)
        {
            foreach(var sonuc in input)
            {
                for(int i =0; i<sonuc.sonuc.Count-1;i++)
                {
                    this.cizim.kenarRenkveLabelEkle(Nodeolusturucusu.vanalar.IndexOf(sonuc.sonuc[i]), Nodeolusturucusu.vanalar.IndexOf(sonuc.sonuc[i + 1]), "red",sonuc.sonuckapasite.ToString());
                }
            }
        }
        public void grafGidilenYollarCiz(List<yol> input)
        {
            
                for (int i = 0; i < input.Count ; i++)
                {
                    this.cizim.kenarRenkDegistir(Nodeolusturucusu.vanalar.IndexOf(Nodeolusturucusu.NodeSearch(Nodeolusturucusu.vanalar, input[i].yolpath.Split(' ')[0])), Nodeolusturucusu.vanalar.IndexOf(Nodeolusturucusu.NodeSearch(Nodeolusturucusu.vanalar, input[i].yolpath.Split(' ')[1])), "green");
                }
           
        }
        string yazdirici(string dot, string outputFileName)
        {
            string output = outputFileName;
            File.WriteAllText(output, dot);
            // assumes dot.exe is in the path EnvVar:
            var args = string.Format(@"{0} -Tjpg -O", output);
            Process p = Process.Start("dot.exe", args);
            p.WaitForExit();
            return output;

        }
    }
}
