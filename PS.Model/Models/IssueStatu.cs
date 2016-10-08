using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class IssueStatu
    {
        public IssueStatu()
        {
            this.Issues = new List<Issue>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
