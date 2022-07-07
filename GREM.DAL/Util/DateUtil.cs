using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace GREM.DAL.Util
{
    public class DateUtil
    {

        public int GetSemanaByData(DateTime data)
        {
            CultureInfo cul = CultureInfo.CurrentCulture;
            
            return cul.Calendar.GetWeekOfYear(data, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }

        public AnoSemana GetSemanasByAno(int ano)
        {
            AnoSemana anoSemana = new AnoSemana();
            anoSemana.Ano = ano;
            List<Semana> lsSemana = new List<Semana>();
            CultureInfo cul = CultureInfo.CurrentCulture;
            const int DAYS_ON_WEEK = 7;
            int daysYear = cul.Calendar.GetDaysInYear(ano);
            int qtdWeek = daysYear / DAYS_ON_WEEK;

            //startyear
            DateTime firstDay = new DateTime(ano, 1, 1);
            int dayOfWeekFirstDay = (int)firstDay.DayOfWeek;
            int qtdDaysToSunday = (DAYS_ON_WEEK - dayOfWeekFirstDay);
            DateTime startSecondWeek = firstDay.AddDays(qtdDaysToSunday);

            Dictionary<int, Dictionary<DateTime, DateTime>> weekAndDatesStartEnd = new Dictionary<int, Dictionary<DateTime, DateTime>>();
            //firstDay.


            var fisrt = cul.Calendar.GetWeekOfYear(firstDay, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
            var lastWeekAdd = new DateTime();

            for (int i = 0; i < qtdWeek + 1; i++)
            {
                Semana s = new Semana();
                Dictionary<DateTime, DateTime> datas = new Dictionary<DateTime, DateTime>();
                var dataInicio = new DateTime();
                var dataFim = new DateTime();
                //primeira semana
                if (i == 0)
                {
                    dataInicio = firstDay;
                    dataFim = firstDay.AddDays(qtdDaysToSunday - 1);
                    //datas.Add(firstDay, firstDay.AddDays(qtdDaysToSunday - 1));
                    //weekAndDatesStartEnd.Add(i + 1, datas);
                }
                else if (i == 1)
                {
                    lastWeekAdd = firstDay.AddDays(qtdDaysToSunday);
                    //datas.Add(lastWeekAdd, lastWeekAdd.AddDays(DAYS_ON_WEEK - 1));
                    //weekAndDatesStartEnd.Add(i + 1, datas);

                    dataInicio = lastWeekAdd;
                    dataFim = lastWeekAdd.AddDays(DAYS_ON_WEEK - 1);
                }
                //última semana
                else if (i == qtdWeek)
                {
                    lastWeekAdd = lastWeekAdd.AddDays(DAYS_ON_WEEK);
                    //datas.Add(lastWeekAdd, new DateTime(ano, 12, 31));
                    //weekAndDatesStartEnd.Add(i + 1, datas);
                    dataInicio = lastWeekAdd;
                    dataFim = new DateTime(ano, 12, 31);
                }
                else
                {
                    lastWeekAdd = lastWeekAdd.AddDays(DAYS_ON_WEEK);
                    //datas.Add(lastWeekAdd, lastWeekAdd.AddDays(DAYS_ON_WEEK - 1));
                    //weekAndDatesStartEnd.Add(i + 1, datas);
                    dataInicio = lastWeekAdd;
                    dataFim = lastWeekAdd.AddDays(DAYS_ON_WEEK - 1);
                }
                s.NumeroSemana = i + 1;
                s.StartDate = dataInicio;
                s.EndDate = dataFim;
                s.StartDateFormatada = dataInicio.ToString("dd/MM/yyyy");
                s.EndDateFormatada = dataFim.ToString("dd/MM/yyyy");  // String.Format("{d}", dataInicio);
                lsSemana.Add(s);
            }
            anoSemana.ListaSemana = lsSemana;
            return anoSemana;

        }
    }

    public class Semana
    {
        public int NumeroSemana { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartDateFormatada { get; set; }
        public string EndDateFormatada { get; set; }
    }

    public class AnoSemana
    {
        public List<Semana> ListaSemana { get; set; }
        public int Ano { get; set; }
    }

    
}