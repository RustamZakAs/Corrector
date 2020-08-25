using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrector
{
    class EDoc
    {
        public string TIN { get; internal set; }
        public string Name { get; internal set; }
        public DateTime Date { get; internal set; }
        public string Serial { get; internal set; }
        public string Number { get; internal set; }
        public string RowCode { get; internal set; }
        public decimal DocMain { get; internal set; }
        public decimal DocEDV { get; internal set; }
        public decimal DocSum { get; internal set; }
        public decimal PayMain { get; internal set; }
        public decimal PayEDV { get; internal set; }
        public decimal PaySum { get; internal set; }
        public bool Corrected { get; internal set; }

        public string ToStringCSV
        {
            get { return TIN + "|" + Name + "|" + Date.Date.ToShortDateString() + "|" +  Serial + "|" + Number + "|" + DocMain + "|" + DocEDV + "|" + DocSum + "|" + PayMain + "|" + PayEDV + "|" + PaySum + "|" + RowCode + "|" + Corrected; }
        }

    }
}
