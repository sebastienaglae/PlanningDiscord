using Discord;
using Discord.Commands;
using PlanningRead;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlanningDiscord
{
    public class InfoModule : ModuleBase<SocketCommandContext>
    {
        [Command("planning")]
        public async Task PlanningAsync()
        {
            DateTime planningDate = new();
            PlanningReader planningReader = new("Edt_Licence_3_Miashs_parcours_Miage.ics", "2021.0.1.3", "BE5E4C87C66B25F0E3DA315EA60FC275", "643d5b312e2e36325d2666683d3126663d3131303030");
            List<Subject> subjects = planningReader.GetByDate(planningDate);
            int minuteOfWork = PlanningTool.WorkingTime(subjects);
            int hourWork = minuteOfWork / 60;
            int minuteWork = minuteOfWork - hourWork * 60;
            int minuteOfFree = PlanningTool.FreeTime(subjects);
            int hourFree = minuteOfFree / 60;
            int minuteFree = minuteOfFree - hourFree * 60;

            var embed = new EmbedBuilder
            {
                Title = "Emploi du temps - Hyperplanning",
                Description = $"Voici l'emploi du temps du **{planningDate.DayToString()} {planningDate.GetDay()} {planningDate.MonthToString()} {planningDate.GetYear()}**",
                Color = Color.DarkMagenta
            };
            embed.AddField("Informations sur la journée",
                $"Il y a __{hourWork}h{minuteWork} de cours/TD__ et __{hourFree}h{minuteFree} de pause !__")
                .WithAuthor(Context.Guild.GetUser(239157875342180353))
                .WithFooter(footer => footer.Text = "Hyperplanning 2021.0.1.3")
                .WithUrl("http://sco.polytech.unice.fr/1/invite?login=true")
                .WithCurrentTimestamp();

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }

        [Command("planning")]
        public async Task PlanningAsync( int day, int month, [Remainder] int year)
        {
            DateTime planningDate = new(day,month,year);
            PlanningReader planningReader = new("Edt_Licence_3_Miashs_parcours_Miage.ics", "2021.0.1.3", "BE5E4C87C66B25F0E3DA315EA60FC275", "643d5b312e2e36325d2666683d3126663d3131303030");
            List<Subject> subjects = planningReader.GetByDate(planningDate);
            int minuteOfWork = PlanningTool.WorkingTime(subjects);
            int hourWork = minuteOfWork / 60;
            int minuteWork = minuteOfWork - hourWork * 60;
            int minuteOfFree = PlanningTool.FreeTime(subjects);
            int hourFree = minuteOfFree / 60;
            int minuteFree = minuteOfFree - hourFree * 60;

            var embed = new EmbedBuilder
            {
                Title = "Emploi du temps - Hyperplanning",
                Description = $"Voici l'emploi du temps du **{planningDate.DayToString()} {planningDate.GetDay()} {planningDate.MonthToString()} {planningDate.GetYear()}**",
                Color = Color.DarkMagenta
            };
            embed.AddField("Informations sur la journée",
                $"Il y a __{hourWork}h{minuteWork} de cours/TD__ et __{hourFree}h{minuteFree} de pause !__")
                .WithAuthor(Context.Guild.GetUser(239157875342180353))
                .WithFooter(footer => footer.Text = "Hyperplanning 2021.0.1.3")
                .WithUrl("http://sco.polytech.unice.fr/1/invite?login=true")
                .WithCurrentTimestamp();

            await Context.Channel.SendMessageAsync(embed: embed.Build());
        }
    }
}
