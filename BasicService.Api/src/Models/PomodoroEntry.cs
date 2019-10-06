using System;
using System.ComponentModel.DataAnnotations;

namespace BasicService.Api.Models {
    public class BasicServiceEntryModel {
        [Key]
        public virtual long Id {get;set;}
        public virtual string UserId { get; set; }
        public virtual DateTime StartTime { get; set; }        
        public virtual DateTime Modified {get; set;}
        public virtual string Planned { get; set; }
        public virtual string Actual {get; set;}
        public virtual int Elapsed { get; set; }
        public virtual string Tags { get; set; }
        public virtual BasicServiceState State { get; set; }
    }
    public enum BasicServiceState {
        NotStarted = 1,
        Running = 2,
        Distracted = 3,
        Interrupted = 4,
        Complete = 5
    }
    
}