﻿namespace PFMS.Entities.DTO
{
    public class PrintingMachineDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string MachineType { get; set; }
        public string EmployeeInCharge { get; set; }
        public bool OnRepair { get; set; }
    }
}