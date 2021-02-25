using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace yazlab3Form
{
    class node
    {
        public node(int index,string label)
        {
            this.index = index;
            this.label = label;

        }
        public node(int index)
        {
            this.index = index;
            this.label = null;
        }
       public int index;
        public string label;
    }
    class kenar
    {
        public kenar(int first, int second, string label,string color)
        {

            this.first = first;
            this.second = second;
            this.label = label;
            this.color = color;
        }
        public kenar(int first,int second,string label)
        {
          
            this.first = first;
            this.second = second;
            this.label = label;
         }
        public kenar()
        {
            this.label = null;
            this.color = null;
        }
        public int first;
        public int second;
        public string label;
        public string color;
    }
    class dotCizimMotoru
    {
        List<node> nodelar = new List<node>();
        List<kenar> kenarlar = new List<kenar>();
       public void nodeEkle(int index,string label)
        {
            if (nodeIndexOf(index) == -1)
                nodelar.Add(new node(index, label));
        }
       public void kenarekle(int first,int second,string label)
        {
            if((kenarlarIndexOf(first,second) ==-1) && (kenarlarIndexOf(second,first) == -1))
            {
                kenarlar.Add(new kenar(first,second,label));
            }
            
        }
      public  void kenarRenkDegistir(int first,int second,string color)
        {
            if ((kenarlarIndexOf(first, second) != -1))
            {
                kenarlar[(kenarlarIndexOf(first, second))].color = color;
            }
            else if ((kenarlarIndexOf(second, first) != -1))
            {
                kenarlar[(kenarlarIndexOf(second, first))].color = color;

            }
        }
        public void kenarRenkveLabelEkle(int first, int second, string color,string Label)
        {
            if ((kenarlarIndexOf(first, second) != -1))
            {
                kenarlar[(kenarlarIndexOf(first, second))].color = color;
                kenarlar[(kenarlarIndexOf(first, second))].label += " - "+ Label;
            }
            else if ((kenarlarIndexOf(second, first) != -1))
            {
                kenarlar[(kenarlarIndexOf(second, first))].color = color;
                kenarlar[(kenarlarIndexOf(second, first))].label += " - " + Label;

            }
        }
        public string toDot()
        {
            string result = "graph G {\r\n";
            foreach(var node in nodelar)
            {
                result += node.index.ToString()+ " ";
                if(node.label != null)
                {
                    result += "[label=\"" + node.label + "\"]";
                }
                    result+=";\r\n";
            }
            foreach(var kenar in kenarlar)
            {
                result += kenar.first + " -- " + kenar.second + " ";
                if (kenar.label != null && kenar.color !=null)
                {
                    result += "[label=\"" + kenar.label + "\" color=" + kenar.color + "]";
                }
                else if (kenar.label != null)
                {
                    result += "[label=\"" + kenar.label + "\"]";
                }
                else if (kenar.color != null)
                {
                    result += "[color=" + kenar.color + "]";

                }
                result += ";\r\n";
            }
            result += "}";
            return result;
        }
        public int kenarlarIndexOf(int first,int second)
        {
            int count = 0;
           foreach(var kenar in kenarlar)
            {
                if ((kenar.first == first) && (kenar.second == second))
                    return count;
                count++;
            }
            return -1;
        }
        public int nodeIndexOf(int index)
        {
            int count = 0;
            foreach (var node in nodelar)
            {
                if ((node.index == index))
                    return count;
                count++;
            }
            return -1;
        }
    }
}
