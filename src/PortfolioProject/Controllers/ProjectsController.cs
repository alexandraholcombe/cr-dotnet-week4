﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PortfolioProject.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioProject.Controllers
{
    public class ProjectsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Project> allProjects = Project.GetProjects();
            return View(allProjects);
        }
    }
}
