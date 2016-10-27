//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PFMS.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class PrintingMachine
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrintingMachine()
        {
            this.MachinesForRepairs = new HashSet<MachinesForRepair>();
            this.ProductsToMachines = new HashSet<ProductsToMachine>();
        }
    
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int MachineTypeId { get; set; }
        public int EmployeeInChargeId { get; set; }
    
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MachinesForRepair> MachinesForRepairs { get; set; }
        public virtual TypesOfMachine TypesOfMachine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductsToMachine> ProductsToMachines { get; set; }
    }
}