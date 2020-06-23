//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class MovieTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MovieTable()
        {
            this.Shows = new HashSet<Show>();
        }
    
        public int MovieId { get; set; }
        public string Category { get; set; }
        public string Trailer { get; set; }
        public string MovieName { get; set; }
        public string ReleaseDate { get; set; }
        public string Language { get; set; }
        public int Rating { get; set; }
        public string ImageAddress { get; set; }
        public string Synopsis { get; set; }
        public Nullable<int> Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Show> Shows { get; set; }
    }
}
