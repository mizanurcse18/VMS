using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class Issue
    {
        public string ID { get; set; }
        public string VehicleID { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string StatusID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string ReportedBy { get; set; }
        public string AssignedTo { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ActionType { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public virtual IssueStatu IssueStatu { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
