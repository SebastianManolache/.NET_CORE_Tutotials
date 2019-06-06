using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Interfaces;
using WebApplication1.Services;

namespace WebApplication1.Models
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString ()
        {

            using (var db = new ClubDbContext())
            {

                var clubs = db.Club.ToList();



                var sb = new StringBuilder();
                sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body>
                                <div class='header'><h1>This is the generated PDF report!!!</h1></div>
                                <table align='center'>
                                    <tr>
                                        <th>Id</th>
                                        <th>Name</th>
                                        <th>Coach</th>
                                        <th>FoundationData</th>
                                        <th>Players</th>
                                    </tr>");

                foreach (var club in clubs)
                {
                    sb.AppendFormat(@"<tr>
                                    <td>{0}</td>
                                    <td>{1}</td>
                                    <td>{2}</td>
                                    <td>{3}</td>
                                  </tr>", club.Id, club.Name, club.Coach, club.FoundationData,club.Players);
                }

                sb.Append(@"
                                </table>
                            </body>
                        </html>");

                return sb.ToString();
            }
        }
    }
}
