using System.Collections.Generic;

namespace PS.Web.UI.Models
{
    public class TreeViewPageNode : TreeViewNode
    {
        public bool IsExpanded { get; set; }
        
        public IEnumerable<TreeViewPageNode> ChildNodes { get; set; }
    }
}