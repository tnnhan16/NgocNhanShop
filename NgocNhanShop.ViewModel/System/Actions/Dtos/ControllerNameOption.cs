using NgocNhanShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NgocNhanShop.ViewModel.System.Actions.Dtos
{
    public class ControllerNameOption
    {
        public string ControllerName { get; set; }
        public List<ActionNameOption> ActionNameOptions { get; set; }
    }
}
