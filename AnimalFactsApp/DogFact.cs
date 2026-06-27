using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalFactsApp
{
    internal class DogFact
    {
        // Свойства для хранения ответа от Dog API
        public List<string> Facts { get; set; }
        public bool Success { get; set; }
    }
}
