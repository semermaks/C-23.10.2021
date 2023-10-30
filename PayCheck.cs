using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Hag_23._10._2021
{
    [Serializable]
    class PayCheck : ISerializable
    {
        public double DayPay { get; set; }
        public int CountOfDays { get; set; }
        public double FineOFneDayMissingPay { get; set; }
        public int CountOfMissingDays { get; set; }
        public double PaySumm { get; protected set; }
        public double Fine { get; protected set; }
        public double GlobalSumm { get; protected set; }
        public bool Serializableprocess { get; set; }
        public PayCheck(double DayPay, int CountOfDays, double FineOFneDayMissingPay, int CountOfMissingDays)
        {
            this.DayPay = DayPay;
            this.CountOfDays = CountOfDays;
            this.FineOFneDayMissingPay = FineOFneDayMissingPay;
            this.CountOfMissingDays = CountOfMissingDays;
            this.PaySumm = CountOfDays * DayPay;
            this.Fine = FineOFneDayMissingPay * CountOfMissingDays;
            this.GlobalSumm = Fine + PaySumm;
            Serializableprocess = true;
        }
        public PayCheck(double DayPay, int CountOfDays, double FineOFneDayMissingPay, int CountOfMissingDays, bool Serializableprocess)
        {
            this.DayPay = DayPay;
            this.CountOfDays = CountOfDays;
            this.FineOFneDayMissingPay = FineOFneDayMissingPay;
            this.CountOfMissingDays = CountOfMissingDays;
            this.PaySumm = CountOfDays * DayPay;
            this.Fine = FineOFneDayMissingPay * CountOfMissingDays;
            this.GlobalSumm = Fine + PaySumm;
            this.Serializableprocess = Serializableprocess;
        }
        public PayCheck(SerializationInfo info, StreamingContext context)
        {
            this.DayPay = double.Parse(info.GetString("DayPay"));
            this.CountOfDays = int.Parse(info.GetString("CountOfDays"));
            this.FineOFneDayMissingPay = double.Parse(info.GetString("FineOFneDayMissingPay"));
            this.CountOfMissingDays = int.Parse(info.GetString("CountOfMissingDays"));
            this.Serializableprocess = bool.Parse(info.GetString("Serializableprocess"));
            if (Serializableprocess)
            {
                this.PaySumm = double.Parse(info.GetString("PaySumm"));
                this.Fine = double.Parse(info.GetString("Fine"));
                this.GlobalSumm = double.Parse(info.GetString("GlobalSumm"));
            }
            else
            {
                this.PaySumm = CountOfDays * DayPay;
                this.Fine = FineOFneDayMissingPay * CountOfMissingDays;
                this.GlobalSumm = Fine + PaySumm;
            }
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DayPay", DayPay);
            info.AddValue("CountOfDays", CountOfDays);
            info.AddValue("FineOFneDayMissingPay", FineOFneDayMissingPay);
            info.AddValue("CountOfMissingDays", CountOfMissingDays);
            info.AddValue("Serializableprocess", Serializableprocess);
            if (Serializableprocess)
            {
                info.AddValue("PaySumm", PaySumm);
                info.AddValue("Fine", Fine);
                info.AddValue("GlobalSumm", GlobalSumm);
            }
        }
        public override string ToString()
        {
            return $"Day pay: {DayPay},\nCount of days: {CountOfDays},\nFine of day missing pay: {FineOFneDayMissingPay}," +
                $"\nCount of missing days: {CountOfMissingDays},\nPay summ: {PaySumm},\nFine: {Fine},\nGlobal summ: {GlobalSumm};";
        }
    }
}
