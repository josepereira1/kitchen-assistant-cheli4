using cheli4.Models;
using cheli4.Models.RecursosHumanos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cheli4.shared
{
    public class QuizHandling : Controller
    {
        private readonly DataBaseContext _context; // para ter acesso à BD

        public QuizHandling(DataBaseContext context)
        {
            this._context = context;
        }
    }
}
