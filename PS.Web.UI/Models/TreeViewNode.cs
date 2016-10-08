using System;

namespace PS.Web.UI.Models
{
    public class TreeViewNode
    {
        public String ID { get; set; }

        public String ParentID { get; set; }

        public string NodeName { get; set; }

        public bool IsSelected { get; set; }
    }
}