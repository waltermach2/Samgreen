using System;

namespace insurance.api.Dtos
{
    public class PolicyForRegisterDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InitialDate { get; set; }
        public int Period { get; set; }
        public string RiskScale { get; set; }
        public double Price { get; set; }
        public int CoveringTypeId { get; set; }
    }
}
