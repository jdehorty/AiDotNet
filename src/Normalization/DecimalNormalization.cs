﻿namespace AiDotNet.Normalization;

public class DecimalNormalization : INormalization
{
    internal override double[] Normalize(double[] rawValues)
    {
        var normalizedValues = new double[rawValues.Length];
        var maxValue = rawValues.Max(Math.Abs);

        var smallestMult = 0;
        for (var i = 1; i < 100; i++)
        {
            if (!(maxValue / Math.Pow(10, i) <= 1)) continue;
            smallestMult = i;
            break;
        }

        if (smallestMult == 0)
        {
            throw new ArgumentException(
                "There are either too many decimals in the raw values or there are invalid values such as NaN or Infinity in the raw values", nameof(rawValues));
        }

        for (var i = 0; i < rawValues.Length; i++)
        {
            normalizedValues.SetValue(rawValues[i] / Math.Pow(10, smallestMult), i);
        }

        return normalizedValues;
    }

    internal override (double[], double[], double[], double[]) PrepareData(double[] inputs, double[] outputs, int trainingSize)
    {
        var (trainingInputs, trainingOutputs, oosInputs, oosOutputs) = NormalizationHelper.SplitData(inputs, outputs, trainingSize);
        
        return (Normalize(trainingInputs), Normalize(trainingOutputs), Normalize(oosInputs), Normalize(oosOutputs));
    }
}