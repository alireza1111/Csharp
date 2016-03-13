using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produktionsdata_syningsbänk
{
    class BandData
    {
        private string Ordernr;
        private string Ringnr;
        private int Bredd;
        private int Vikt;
        private string Stålsort;
        private string Ag;
        private string Matnr;
        private string Kkod;
        private string Härdat;
        private string Slutval;

        public string ordernr
        {
            get
            {
                return this.Ordernr;
            }
            set
            {
                this.Ordernr = value;
            }
        }

        public string ringnr
        {
            get
            {
                return this.Ringnr;
            }
            set
            {
                this.Ringnr = value;
            }
        }

        public string ag
        {
            get
            {
                return this.Ag;
            }
            set
            {
                this.Ag = value;
            }
        }

        public string stålsort
        {
            get
            {
                return this.Stålsort;
            }
            set
            {
                this.Stålsort = value;
            }
        }

        public string matnr
        {
            get
            {
                return this.Matnr;
            }
            set
            {
                this.Matnr = value;
            }
        }

        public string kkod
        {
            get
            {
                return this.Kkod;
            }
            set
            {
                this.Kkod = value;
            }
        }

        public string härdet
        {
            get
            {
                return this.Härdat;
            }
            set
            {
                this.Härdat = value;
            }
        }

        public string slutval
        {
            get
            {
                return this.Slutval;
            }
            set
            {
                this.Slutval = value;
            }
        }

        public int bredd
        {
            get
            {
                return this.Bredd;
            }
            set
            {
                this.Bredd = value;
            }
        }

        public int vikt
        {
            get
            {
                return this.Vikt;
            }
            set
            {
                this.Vikt = value;
            }
        }

    }



}
