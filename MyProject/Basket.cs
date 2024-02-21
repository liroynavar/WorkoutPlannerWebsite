using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject
{
    public class SelectedItem
    {
        private string Name;
        private string Muscle;
        private string link;

        public string NameOfEx
        {
            get { return Name; }
            set { Name = value; }
        }
        public string ExMuscle
        {
            get { return Muscle; }
            set { Muscle = value; }
        }
        public string ExLink
        {
            get { return link; }
            set { link = value; }
        }
    }
    public class Basket
    {
        private ArrayList ExBasket = new ArrayList();
        public ArrayList BasketList
        {
            get { return ExBasket; }
            set { ExBasket = value; }
        }
        public void ADDitem(SelectedItem i)
        {
            ExBasket.Add(i);
        }
    }
}
