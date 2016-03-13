using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produktionsdata_syningsbänk
{
    class Avmärkningar
    {
        private int start;
        private int slut;
        private string S;  //Klassering
        private string YtaK;
        private string Tjöckhet;
        private string planhet;
        private string kommentar;
        private string fel;  //

        public int Start
        {
            get
            {
                return this.start;
            }
            set
            {
                this.start = value;
            }
        }

        public int Slut
        {
            get
            {
                return this.slut;
            }
            set
            {
                this.slut = value;
            }
        }
        
        public string s
        {
            get
            {
                return this.S;
            }
            set
            {
                this.S = value;
            }
        }

        public string Fel
        {
            get
            {
                return this.fel;
            }
            set
            {
                this.fel = value;
            }
        }
        public string ytak
        {
            get
            {
                return this.YtaK;
            }
            set
            {
                this.YtaK = value;
            }
        }
        public string tjöckhet
        {
            get
            {
                return this.Tjöckhet;
            }
            set
            {
                this.Tjöckhet = value;
            }
        }
        public string Planhet
        {
            get
            {
                return this.planhet;
            }
            set
            {
                this.planhet = value;
            }
        }
        public string Kommentar
        {
            get
            {
                return this.kommentar;
            }
            set
            {
                this.kommentar = value;
            }
        }

        public override string ToString()
        {
            return String.Format("{0,-10:G}{1, -10:G}{2, -10:G}{3, -10:G}{4, -10:G} {5, -10:G} {6, -10:G} {7, -10:G}", Start, Slut, Fel, s, ytak, tjöckhet, Planhet, Kommentar);
        }
    }
}
