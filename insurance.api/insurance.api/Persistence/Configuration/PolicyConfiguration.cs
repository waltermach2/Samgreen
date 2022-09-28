using insurance.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using static insurance.api.Common.Enums.Enums;

namespace insurance.api.Persistence.Configuration
{
    public class PolicyConfiguration
    {
        public PolicyConfiguration(EntityTypeBuilder<Policy> entityBuilder)
        {
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(80);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(250);
            entityBuilder.Property(x => x.InitialDate).IsRequired();
            entityBuilder.Property(x => x.Period).IsRequired();
            entityBuilder.Property(x => x.Price).HasColumnType("decimal(5,2)");
            entityBuilder.Property(x => x.RiskScale).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Period).IsRequired();

            //Risk Scale
            Array values = Enum.GetValues(typeof(RiskScale));
            Random randomRiksScale = new Random();

            //Policies by default
            var policies = new List<Policy>();
            var randomAmount = new Random();

            //Period
            var randomPeriod = new Random();

            //Covering Type
            var randomPercentage = new Random();

            //Initial Date
            var dateRandom = new Random();
            DateTime RandomDay()
            {
                DateTime start = new DateTime(1995, 1, 1);
                int range = (DateTime.Today - start).Days;
                return start.AddDays(dateRandom.Next(range));
            }

            for (int i = 1; i <= 10; i++)
            {
                RiskScale riskScale = (RiskScale)values.GetValue(randomRiksScale.Next(values.Length));

                //policies.Add(new Policy
                //{
                //    Id = i,
                //    Name = $"Policy {i}",
                //    Description = $"Description Policy {i}",
                //    InitialDate = RandomDay(),
                //    Period = randomPeriod.Next(1, 12),
                //    Price = randomAmount.Next(10, 1000),
                //    RiskScale = riskScale.ToString(),
                //    CoveringType = new CoveringType { Type = "Stole", Percentage = randomPercentage.Next(1, 100) }
                //});
            }

            entityBuilder.HasData(policies);
        }
    }
}
