using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace TerVerMVVM.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Свойства

        public double? M1 { get; set; }
        public double? M2 { get; set; }
        public double? M3 { get; set; }
        public double? M4 { get; set; }

        public double? V2 { get; set; }
        public double? V3 { get; set; }
        public double? V4 { get; set; }
        public double? V5 { get; set; }

        public double? Xmod { get; set; }
        public double? Xmed { get; set; }

        public double? Kas { get; set; }
        public double? Kex { get; set; }

        public double? Sx { get; set; }

        public string Seq { get; set; }
        public string VarSeq { get; set; }

        private readonly Calculator _calculator;

        #endregion

        #region События

        #endregion

        #region Конструкторы

        public MainViewModel()
        {
            _calculator = new Calculator();
        }

        #endregion

        #region Команды

        public ICommand CalcCommand => new RelayCommand(OnCalc);

        private void OnCalc(object obj)
        {
            if (Seq == String.Empty)
                return;
            var seq = ParseStandart(Seq);
            if (seq != null)
            {
                _calculator.Calc(seq);
                M1 = _calculator.Mn(1);
                M2 = _calculator.Mn(2);
                M3 = _calculator.Mn(3);
                M4 = _calculator.Mn(4);

                V2 = _calculator.Vn(2);
                V3 = _calculator.Vn(3);
                V4 = _calculator.Vn(4);
                V5 = _calculator.Vn(5);

                Xmod = _calculator.XMod();
                Xmed = _calculator.XMed();

                Sx = _calculator.Sx();

                Kas = _calculator.Kas();
                Kex = _calculator.Kex();

                VarSeq = string.Join(" ", _calculator.VarSeq());
            }
        }

        #endregion

        #region Методы

        private List<double> ParseStandart(string seq, bool flag = true)
        {
            try
            {
                var s = seq;
                s = s.Replace("−", "-");
                var input = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
                if (!flag) return input;
                // Ооо, повезло, повезло
                return input;
            }
            catch (Exception)
            {
                if (!flag)
                {
                    // Ввод некорректен
                    return null;
                }
                // Статус: Обычный метод - ошибка. Выбран метод с большими N!
                return ParseManyN(seq, false);
            }
        }

        private List<double> ParseManyN(string seq, bool flag = true)
        {
            try
            {
                var s = seq;
                var input = new List<double>();
                var str = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (var word in str)
                {
                    var str2 = word.Split(new[] { ':' }).Select(double.Parse).ToList();
                    for (var i = 0; i < str2[1]; i++)
                    {
                        input.Add(str2[0]);
                    }
                }
                // Ооо, повезло,повезло
                return input;
            }
            catch (Exception)
            {
                if (!flag)
                {
                    // Ввод некорректен
                    return null;
                }
                // Статус: При больших N - ошибка. Выбран обычный метод!
                return ParseStandart(seq, false);
            }
        }

        #endregion

    }
}
