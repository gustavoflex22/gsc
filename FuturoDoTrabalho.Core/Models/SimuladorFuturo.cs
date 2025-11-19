using System;
using System.Text;

namespace FuturoDoTrabalho.Models
{
    public sealed class FutureWorkSimulator
    {
        private const double LowIndexUpperLimit = 25d;
        private const double RegularIndexUpperLimit = 50d;
        private const double GoodIndexUpperLimit = 75d;

        private readonly PapelTrabalho _workRole;

        public FutureWorkSimulator(PapelTrabalho workRole)
        {
            _workRole = workRole ?? throw new ArgumentNullException(nameof(workRole));
        }

        public double CalculateFutureIndex(
            double automation,
            double wellbeing,
            double inclusion,
            double sustainability)
        {
            return _workRole.CalculateBaseIndex(automation, wellbeing, inclusion, sustainability);
        }

        public string ClassifyIndex(double index)
        {
            if (index < LowIndexUpperLimit)
            {
                return "Baixo – O modelo atual ainda está distante de um trabalho do futuro saudável e sustentável.";
            }

            if (index < RegularIndexUpperLimit)
            {
                return "Regular – Já existem elementos positivos, mas há muito espaço para evoluir.";
            }

            if (index < GoodIndexUpperLimit)
            {
                return "Bom – O trabalho está bem alinhado com tendências de IA, bem-estar e inclusão.";
            }

            return "Excelente – Seu trabalho está altamente alinhado com o futuro: humano, criativo e sustentável.";
        }

        public string GenerateRecommendations(
            double automation,
            double wellbeing,
            double inclusion,
            double sustainability)
        {
            var recommendations = new StringBuilder();

            recommendations.AppendLine("Sugestões para aproximar seu trabalho do futuro:");

            if (automation < 6)
            {
                recommendations.AppendLine("• Investir em automação com IA para tarefas repetitivas, liberando tempo para atividades criativas.");
            }

            if (wellbeing < 7)
            {
                recommendations.AppendLine("• Implementar políticas de bem-estar: pausas, flexibilidade de horário, acompanhamento de saúde mental.");
            }

            if (inclusion < 7)
            {
                recommendations.AppendLine("• Fortalecer programas de diversidade e inclusão, com treinamentos e canais seguros de escuta.");
            }

            if (sustainability < 7)
            {
                recommendations.AppendLine("• Adotar práticas mais sustentáveis: redução de deslocamentos, energia limpa, consumo consciente.");
            }

            return recommendations.ToString().TrimEnd();
        }
    }
}

