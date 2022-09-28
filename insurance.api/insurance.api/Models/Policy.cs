using System;

namespace insurance.api.Models
{
    public class Policy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime InitialDate { get; set; }
        public int Period { get; set; }
        public double Price { get; set; }
        public string RiskScale { get; set; }
        public double CoveringPercentage { get; set; }
    }
}
