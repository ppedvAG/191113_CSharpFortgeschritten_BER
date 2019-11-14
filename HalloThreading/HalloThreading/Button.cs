using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloThreading
{
    class Button
    {
        // Variante "Lang"
        //private EventHandler buttonClick;
        //public event EventHandler ClickEvent
        //{
        //    add
        //    {
        //        buttonClick += value;
        //    }
        //    remove
        //    {
        //        buttonClick -= value;
        //    }
        //}


        // Variante "Kurz"
        public event EventHandler ClickEvent;// "AutoProperty"

        public void Click()
        {
            // Logik
            if(ClickEvent != null)
                ClickEvent(this, EventArgs.Empty);
        }
    }
}
