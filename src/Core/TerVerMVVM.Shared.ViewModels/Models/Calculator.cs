using System;
using System.Collections.Generic;
using System.Linq;

namespace TerVerMVVM.Shared.ViewModels
{
    public class Calculator
    {
        #region Свойства

        private List<double> _sequence;

        #endregion


        #region Конструкторы



        #endregion

        #region Методы

        public void Calc(List<double> sequence)
        {
            _sequence = sequence;
        }

        public double Mn(int n)
        {
            var sum = _sequence.Sum(num => Math.Pow(num, n));
            return sum / _sequence.Count;
        }

        public double Vn(int n)
        {
            var m1 = Mn(1);
            var sum = _sequence.Sum(num => Math.Pow(num - m1, n));
            return sum / _sequence.Count;
        }

        public double Sx()
        {
            var m1 = Mn(1);
            var sum = _sequence.Sum(num => Math.Pow(num - m1, 2));
            return sum / (_sequence.Count - 1);
        }

        public double XMod()
        {
            return _sequence.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
        }

        public double XMed()
        {
            var seq = _sequence;
            seq.Sort();
            return seq.Count % 2 == 1 ? seq[seq.Count / 2] : ((seq[seq.Count / 2] + seq[seq.Count / 2 - 1]) / 2);
        }

        public double Kas()
        {
            return Vn(3) / Math.Pow(Math.Sqrt(Vn(2)), 3);
        }

        public double Kex()
        {
            return Vn(4) / Math.Pow(Math.Sqrt(Vn(2)), 4) - 3;
        }

        public List<double> VarSeq()
        {
            var varSeq = _sequence;
            varSeq.Sort();
            return varSeq;
        }

        #endregion
    }
}