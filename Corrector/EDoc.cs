using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrector
{
    public class EDoc
    {
        public string TIN { get; internal set; }
        public string Name { get; internal set; }
        public DateTime Date { get; internal set; }
        public string Serial { get; internal set; }
        public string Number { get; internal set; }
        public string RowCode { get; internal set; }
        public decimal DocMain { get; internal set; }
        public decimal DocVAT { get; internal set; }
        public decimal DocSum { get; internal set; }
        public decimal PayMain { get; internal set; }
        public decimal PayVAT { get; internal set; }
        public decimal PaySum { get; internal set; }
        public bool Corrected { get; internal set; }

        public static string ToStringColumnsCSV()
        {
            return nameof(TIN) + "|" + nameof(Name) + "|" + nameof(Date) + "|" + nameof(Serial) + "|" + nameof(Number) + "|" + nameof(DocMain) + "|" + nameof(DocVAT) + "|" + nameof(DocSum) + "|" + nameof(PayMain) + "|" + nameof(PayVAT) + "|" + nameof(PaySum) + "|" + nameof(RowCode) + "|" + nameof(Corrected);
        }
        public string ToStringCSV()
        {
            return TIN + "|" + Name + "|" + Date.Date.ToShortDateString() + "|" + Serial + "|" + Number + "|" + DocMain + "|" + DocVAT + "|" + DocSum + "|" + PayMain + "|" + PayVAT + "|" + PaySum + "|" + RowCode + "|" + Corrected;
        }
    }
}
