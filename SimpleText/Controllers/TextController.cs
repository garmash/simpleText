using Microsoft.AspNetCore.Mvc;
using SimpleText.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleText.Controllers
{
    public class TextController : Controller
    {
        private readonly IGetText _allText;

        public TextController(IGetText iGetText) {
            _allText = iGetText;
        }
 
        public ViewResult VText()
        {
            var text = _allText.AllTextString;
            return View(text);
        }

   }
}
