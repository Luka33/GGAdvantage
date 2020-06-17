using System;
using System.Collections.Generic;
using System.Text;

namespace GGAdvantage.Application.Models
{
    public class MenuItemDto : BaseDto
    {
        public string Label { get; set; }
        public List<MenuItemDto> Items { get; set; } 
    }

}
