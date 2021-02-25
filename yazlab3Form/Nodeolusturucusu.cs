using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yazlab3
{
   static class Nodeolusturucusu
    {
        static public List<Vana> vanalar = new List<Vana>();
        static public void NodeOlusturucu(int musluksayisi)
        {
            for(int i =1; i <=musluksayisi; i++)
            {
                vanalar.Add(new Vana(i.ToString()));
            }
        }
        static public  Vana NodeSearch(List<Vana> vanala, string musluk_ismi)
        {
            for(int i = 0; i < vanala.Count; i++)
            {
                if (vanala[i].ismi.Equals(musluk_ismi))
                {
                    return vanala[i];
                   
                }
            }

            return null;
        }
        static public void NodeBilgi(string birinci_musluk,string ikinci_musluk,int kapasite)
        {

            if((Graf.KomsuindexBul(NodeSearch(vanalar, birinci_musluk), NodeSearch(vanalar, ikinci_musluk).ismi) == -1) &&
                (Graf.KomsuindexBul(NodeSearch(vanalar, ikinci_musluk), NodeSearch(vanalar, birinci_musluk).ismi) == -1)) {
               NodeSearch(vanalar, birinci_musluk).komsular.Add(new Komsuvana(NodeSearch(vanalar, ikinci_musluk), kapasite));
            NodeSearch(vanalar,ikinci_musluk).komsular.Add(new Komsuvana(NodeSearch(vanalar,birinci_musluk), kapasite));
            }
            else
            {
                NodeSearch(vanalar, birinci_musluk).komsular[Graf.KomsuindexBul(NodeSearch(vanalar, birinci_musluk), NodeSearch(vanalar, ikinci_musluk).ismi)].kapasite= kapasite;
                NodeSearch(vanalar, ikinci_musluk).komsular[Graf.KomsuindexBul(NodeSearch(vanalar, ikinci_musluk), NodeSearch(vanalar, birinci_musluk).ismi)].kapasite = kapasite;

            }
            
        }
        static public void NodeKomsuDolulukResetleyici()
        {
            foreach (var vana in vanalar)
            {
                foreach(var komsu in vana.komsular)
                {
                    komsu.doluluk = 0;
                }
            }
        }
    }
}
