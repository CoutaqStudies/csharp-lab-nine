//written by Coutaq
using System;

namespace LabNine
{
    public class GeographicalUnit
    {
        private string Country { get; set; }
        private string Capital { get; set; }
        private int Population { get; set; }
        public enum FormOfGov { US, F }
        private FormOfGov Form { get; set; }
        public GeographicalUnit(string country, string capital, int population, FormOfGov form)
        {
            this.Country = country;
            this.Capital = capital;
            this.Population = population;
            this.Form = form;
        }
        public String GetName()
        {
            return Country;
        }
        public int GetPopulation()
        {
            return Population;
        }
        public FormOfGov GetForm()
        {
            return Form;
        }

        public GeographicalUnit()
        {
        }
        public string GetInfoTable()
        {
            String output = String.Format("{0,-10} |{1,-0} |{2,-10} |{3,-2}|", Country, Capital, Population, Form);
            output += "\n--------------------------------------\n";
            return output;
        }
    }
}