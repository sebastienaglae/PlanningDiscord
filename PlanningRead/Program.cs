using System;

namespace PlanningRead
{
    class Program
    {
        static void Main(string[] args)
        {
            String val = PlanningReader.GetIcalContent("http://sco.polytech.unice.fr/1/Telechargements/ical/Edt_Licence_3_Miashs_parcours_Miage.ics?version=2021.0.1.3&idICal=BE5E4C87C66B25F0E3DA315EA60FC275&param=643d5b312e2e36325d2666683d3126663d3131303030");
            Console.WriteLine(PlanningReader.GetAllSubject(val)[0].GetDateStart());
            Console.WriteLine(PlanningReader.GetAllSubject(val)[0].GetDateEnd());
        }
    }
}
