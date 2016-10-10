using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace PS.Web.UI.Helpers
{
    public static class Renders
    {
        public static string RenderPartialView(this Controller controller, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = controller.ControllerContext.RouteData.GetRequiredString("action");

            controller.ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                var viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }

    public static class Extensions
    {
        public static string ToRelativeTime(this DateTime date)
        {
            int Minute = 60;
            int Hour = Minute * 60;
            int Day = Hour * 24;
            int Year = Day * 365;

            var thresholds = new Dictionary<long, Func<TimeSpan, string>>
                {
                    {2, t => "a second ago"},
                    {Minute,  t => String.Format("{0} seconds ago", (int)t.TotalSeconds)},
                    {Minute * 2,  t => "a minute ago"},
                    {Hour,  t => String.Format("{0} minutes ago", (int)t.TotalMinutes)},
                    {Hour * 2,  t => "an hour ago"},
                    {Day,  t => String.Format("{0} hours ago", (int)t.TotalHours)},
                    {Day * 2,  t => "yesterday"},
                    {Day * 30,  t => String.Format("{0} days ago", (int)t.TotalDays)},
                    {Day * 60,  t => "last month"},
                    {Year,  t => String.Format("{0} months ago", (int)t.TotalDays / 30)},
                    {Year * 2,  t => "last year"},
                    {Int64.MaxValue,  t => String.Format("{0} years ago", (int)t.TotalDays / 365)}
                };
            var difference = DateTime.UtcNow - date.ToUniversalTime();
            return thresholds.First(t => difference.TotalSeconds < t.Key).Value(difference);

        }

        public static string MarkLinks(this string input)
        {
            Regex reg = new Regex(@"((?:http|https):\/\/[a-z0-9\/\?=_#&%~-]+(\.[a-z0-9\/\?=_#&%~-]+)+)|(www(\.[a-z0-9\/\?=_#&%~-]+){2,})", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(input);

            foreach (Match match in matches)
            {
                input = input.Replace(match.Value, "<a href='" + match.Value + "' target='_blank'>" + match.Value + "</a>");
            }
            input = input.Replace(Environment.NewLine, "<br />").Replace("\n\n", "<br />").Replace("\n", "<br />");
            return input;
        }

        public static string MarkHastags(this string input)
        {
            Regex reg = new Regex(@"\B#\w*[a-zA-Z]+\w*", RegexOptions.IgnoreCase);
            MatchCollection matches = reg.Matches(input);

            foreach (Match match in matches)
            {
                input = input.Replace(match.Value, "<a href='#' class='hashtag'>" + match.Value + "</a>");
            }
            return input;
        }

        public static string Prep(this string input)
        {
            return System.Security.SecurityElement.Escape(input).MarkLinks().MarkHastags();
        }
    }
}