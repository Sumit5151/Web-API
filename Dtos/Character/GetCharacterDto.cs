using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Dtos.Character
{
    public class GetCharacterDto
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public int HitPointes { get; set; }
        public int Strength { get; set; }
        public int Defence { get; set; }
        public int Intelligence { get; set; }
        public RpgClass Class { get; set; }
        
    }
}