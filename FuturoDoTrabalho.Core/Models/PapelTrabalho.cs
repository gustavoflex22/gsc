using System;

namespace FuturoDoTrabalho.Models
{
    public abstract class PapelTrabalho
    {
        private const double AutomationWeight = 0.25;
        private const double WellbeingWeight = 0.25;
        private const double InclusionWeight = 0.25;
        private const double SustainabilityWeight = 0.25;

        private const double FlexibilityGlobalWeight = 0.4;
        private const double CollaborationGlobalWeight = 0.4;
        private const double OnsiteGlobalWeight = 0.2;

        protected PapelTrabalho(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract double FlexibilityFactor { get; }
        public abstract double CollaborationFactor { get; }
        public abstract double OnsiteFactor { get; }

        public virtual double CalculateBaseIndex(
            double automation,
            double wellbeing,
            double inclusion,
            double sustainability)
        {
            var normalizedScore =
                (automation * AutomationWeight) +
                (wellbeing * WellbeingWeight) +
                (inclusion * InclusionWeight) +
                (sustainability * SustainabilityWeight);

            var weightedScore = normalizedScore * (
                (FlexibilityGlobalWeight * FlexibilityFactor) +
                (CollaborationGlobalWeight * CollaborationFactor) +
                (OnsiteGlobalWeight * OnsiteFactor));

            return Math.Round(weightedScore, 2);
        }
    }

    public sealed class RemoteWorker : PapelTrabalho
    {
        private const double HighWellbeingBonusThreshold = 8d;
        private const double HighWellbeingBonus = 5d;

        public RemoteWorker() : base("Remoto")
        {
        }

        public override double FlexibilityFactor => 1.2;
        public override double CollaborationFactor => 1.0;
        public override double OnsiteFactor => 0.8;

        public override double CalculateBaseIndex(
            double automation,
            double wellbeing,
            double inclusion,
            double sustainability)
        {
            var index = base.CalculateBaseIndex(automation, wellbeing, inclusion, sustainability);

            if (wellbeing >= HighWellbeingBonusThreshold)
            {
                index += HighWellbeingBonus;
            }

            return Math.Round(index, 2);
        }
    }

    public sealed class HybridWorker : PapelTrabalho
    {
        public HybridWorker() : base("Híbrido")
        {
        }

        public override double FlexibilityFactor => 1.1;
        public override double CollaborationFactor => 1.1;
        public override double OnsiteFactor => 1.0;
    }

    public sealed class OnsiteWorker : PapelTrabalho
    {
        private const double LowSustainabilityPenaltyThreshold = 5d;
        private const double LowSustainabilityPenalty = 5d;

        public OnsiteWorker() : base("Presencial")
        {
        }

        public override double FlexibilityFactor => 0.9;
        public override double CollaborationFactor => 1.0;
        public override double OnsiteFactor => 1.2;

        public override double CalculateBaseIndex(
            double automation,
            double wellbeing,
            double inclusion,
            double sustainability)
        {
            var index = base.CalculateBaseIndex(automation, wellbeing, inclusion, sustainability);

            if (sustainability < LowSustainabilityPenaltyThreshold)
            {
                index -= LowSustainabilityPenalty;
            }

            return Math.Round(index, 2);
        }
    }
}

