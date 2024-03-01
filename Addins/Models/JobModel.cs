using System.Collections.Generic;
using Addins.Models;

namespace Addins
{
    public class JobModel
    {
        public int operator_id { get; set; }
        public string job_no { get; set; } 
        public string drawing_no { get; set; } 
        public string handle { get; set; } 
        public string item_no { get; set; } 
        public string insulation { get; set; } 
        public double galvanized { get; set; }
        public string notes { get; set; } 
        public double weight { get; set; }
        public string status { get; set; }
        public int qty { get; set; }
        public string cut_type { get; set; }
        public int cid { get; set; } 
        public string description { get; set; }
        public bool double_wall { get; set; }
        //Todo: update_id ????
        public int update_id { get; set; }
        public double insulation_area { get; set; }
        public double metal_area { get; set; }
        public double insulation_spec { get; set; }
        public double width_dim { get; set; }
        public double depth_dim { get; set; }
        public double length_angle { get; set; }
        public string connector { get; set; }
        public string material { get; set; }
        public string file_name { get; set; }
        public bool bought_out { get; set; }
        public string unique_id { get; set; }
        public int number_metal_parts { get; set; }
        public string prefix_string { get; set; }
        public List<ItemPart> item_parts { get; set; }
        
        // public string operatorId { get; set; } = string.Empty;
        // public string jobday { get; set; } = string.Empty;
        // public string jobtime { get; set; } = string.Empty;
        // [Range(0.01,999999999)]
        // public int pathid { get; set; } = 0;
        // public string boughtout { get; set; } = string.Empty;
        // public string linearmeter { get; set; } = string.Empty;
        // public string sectionindex { get; set; } = string.Empty;
        // public string sectiondescription { get; set; } = string.Empty;
        // public string prefixstring { get; set; } = string.Empty;
        // public string equipmentTag { get; set; } = string.Empty;
        // public string jobArea { get; set; } = string.Empty;
        // public string custom4 { get; set; } = string.Empty;
        // public string emptyString { get; set; } = string.Empty;
    }
}