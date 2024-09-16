using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class ImageFile : BaseEntity
    {
        public int GymId { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public bool Showcase { get; set; }
    }
}
