using App.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.EntityFrameworkCore;
using System.Buffers.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace App.Controllers
{
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public IssueController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Issue()
        {
            return View(new IssueModel());
        }
        [HttpPost]
        public IActionResult AddIssue(IssueModel issue)
        {
            foreach (var item in issue.Images)
            {
                if (item.Img != null)
                {               
                var base64Data = Regex.Match(item.Img, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                item.Image = Convert.FromBase64String(base64Data);
                }
            }
            issue.Date = DateTime.Now;
            issue.State = State.Reported;
            _context.Issues.Add(issue);
            _context.SaveChanges();

            var smtpClient = new SmtpClient("172.16.35.195")
            {
                Port = 25,
                //Credentials = new NetworkCredential("email", "password"),
                EnableSsl = false,
            };
            string photos = PhotoLinks(issue.Images);
            var mailMessage = new MailMessage
            {
                From = new MailAddress(_configuration.GetSection("NotificationMailFrom").Value),
                Subject = "Zgłoszenie awarii: "+issue.IssueId,
                Body = "<p>"+issue.Description+"</p>"+"Zdjęcia: <br>"+ photos,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(_configuration.GetSection("NotificationMailTo").Value);

            smtpClient.Send(mailMessage);

            return RedirectToAction("Index","Home");
        }
        public string PhotoLinks(List<Multimedium> PhotoLinks)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in PhotoLinks)
            {
                if (item.Image != null)
                {
                    result.AppendLine(
                        "<a href = '" + _configuration.GetSection("HostURL").Value + "get.image?img=" + item.MultimediumId.ToString() + "'>zdjęci-" + item.MultimediumId.ToString() + "</a><br>");
                }
            }
            return result.ToString();
        }
    }
}
